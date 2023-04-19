using System.IO;
using System.Text;

public class AutomaticCIBuilder
{
    private StringBuilder _builder;

    #region CI Content

    private string baseContent = @"stages:
  - prepare
  - test
  - build

variables:
  BUILD_NAME: $CI_PROJECT_NAME
  UNITY_EDITOR_DIR: /opt/unity/Editor/Unity
  PROJECT_DIR: $CI_PROJECT_DIR

default:
  image: unityci/editor:$UNITY_VERSION-base-1

get-unity-version:
  image: alpine
  stage: prepare
  variables:
    GIT_DEPTH: 1
  script:
    - echo UNITY_VERSION=$(cat $PROJECT_DIR/ProjectSettings/ProjectVersion.txt | grep ""m_EditorVersion:.*"" | awk '{ print $2}') | tee prepare.env
  artifacts:
    reports:
        dotenv: prepare.env

get_license:
    stage: prepare
    rules:
        - if: '$UNITY_LICENSE == null'
          when: manual
    script:
        - $UNITY_EDITOR_DIR -batchmode -createManualActivationFile
    artifacts:
        paths:
            - ""*.alf""
        expire_in: 10 min

.activate_license: &activate_license
    variables:
        unity_license_destination: license/Unity_lic.ulf
    rules:
        - if: '$UNITY_LICENSE != null'
    before_script:
        - mkdir license
        - echo ""${UNITY_LICENSE}"" | tr -d '\r' > $unity_license_destination
        - $UNITY_EDITOR_DIR -batchmode -manualLicenseFile $unity_license_destination
    
.cache: &cache
    cache:
        key: ""$CI_PROJECT_NAMESPACE-$CI_PROJECT_NAME-$CI_COMMIT_REF_SLUG-$TEST_PLATFORM""
        paths:
            - $UNITY_EDITOR_DIR/Library/

.unity_setup: &unity_setup
    <<:
        - *activate_license
        - *cache
        ";

    private string testEditModeJob = @"
unity_test_editMode:
  <<: *unity_setup
  stage: test
  script:
    - $UNITY_EDITOR_DIR -batchmode -nographics -projectPath . -runTests -testPlatform editmode -testResults ./unit-tests-editmode.xml
  artifacts:
    paths: 
      - unit-tests-editmode.xml
";
    
    private string testPlayModeJob = @"
unity_test_playMode:
  <<: *unity_setup
  stage: test
  script:
    - $UNITY_EDITOR_DIR -batchmode -nographics -projectPath . -runTests -testPlatform playMode -testResults ./unit-tests-playMode.xml
  artifacts:
    paths: 
      - unit-tests-playMode.xml
";

    private string windowsBuildJob = @"
unity-build-windows:
  <<: *unity_setup
  image: unityci/editor:$UNITY_VERSION-windows-mono-1
  stage: build
  script: 
    - $UNITY_EDITOR_DIR -batchmode -nographics -quit -projectPath . -executeMethod BuildUtility.WindowsBuild
    - ls
  artifacts:
    paths:
      - Build/Windows/
";

    private string androidBuildJob = @"
unity-build-android:
  <<: *unity_setup
  image: unityci/editor:$UNITY_VERSION-android-1
  stage: build
  script:
    - $UNITY_EDITOR_DIR -batchmode -nographics -quit -projectPath . -executeMethod BuildUtility.AndroidBuild
  artifacts:
    paths:
      - Build/Android/
";
    
    #endregion
    
    public AutomaticCIBuilder()
    {
        _builder = new StringBuilder();

        _builder.Append(baseContent);
    }

    public void Save()
    {
        StreamWriter file = File.CreateText("./.gitlab-ci.yml");
        file.Write(_builder);
        file.Close();
    }

    public void WithTests(bool editMode, bool playMode)
    {
        if (editMode)
            _builder.Append(testEditModeJob);

        if (playMode)
            _builder.Append(testPlayModeJob);
    }

    public void WithWindowsBuild()
    {
        _builder.Append(windowsBuildJob);
    }

    public void WithAndroidBuild()
    {
        _builder.Append(androidBuildJob);
    }
}