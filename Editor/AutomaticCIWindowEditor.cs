using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AutomaticCIWindowEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset _visualTreeAsset;
    private VisualElement _root;
    
    // Views
    private ConfigurationSelectorView _configurationSelectorView;
    private ConfigurationContentView _configurationContentView;
    
    [MenuItem("AutomaticCI/Settings")]
    public static void OpenWindow()
    {
        AutomaticCIWindowEditor wnd = GetWindow<AutomaticCIWindowEditor>("AutomaticCI");
        wnd.minSize = new Vector2(400, 400);
    }

    public void CreateGUI()
    {
        _root = rootVisualElement;
        _visualTreeAsset.CloneTree(_root);
        
        CreateViews();
        
        RegisterCallbacks();
    }

    private void CreateViews()
    {
        _configurationSelectorView = new ConfigurationSelectorView();
        _root.Add(_configurationSelectorView);
        
        var configuration = AutomaticCISettings.instance.Configuration;
        
        if(configuration != null)
            UpdateConfigurationContent(configuration);
    }

    private void RegisterCallbacks()
    {
        EventBus.onConfigurationFileChanged += OnConfigurationFileChanged;
        EventBus.onChangesReverted += UpdateConfigurationContent;
        EventBus.onChangesApplied += OnChangesApplied;
    }

    private void UnregisterCallbacks()
    {
        EventBus.onConfigurationFileChanged -= OnConfigurationFileChanged;
        EventBus.onChangesReverted -= UpdateConfigurationContent;
        EventBus.onChangesApplied -= OnChangesApplied;
    }
    

    private void OnDestroy()
    {
        UnregisterCallbacks();

        if (PersistenceController.HasUnappliedChanges)
        {
            ShowUnappliedChangesPopUp();
        }
    }

    private void ShowUnappliedChangesPopUp()
    {
        if (PersistenceController.HasUnappliedChanges)
        {
            bool applyClicked = EditorUtility.DisplayDialog(
                "Unapplied configuration changes",
                "Do you want to apply the changes you made in the configuration file? \n \n Your changes will be lost if you don't apply them.",
                "Apply", 
                "Revert");

            if (applyClicked)
            {
                var configuration = AutomaticCISettings.instance.Configuration;
                var configurationTmp = ConfigurationContentController.ConfigurationTmp;
                
                PersistenceUtility.Copy(configurationTmp, configuration);
                
                GenerateGitlabCIFile(configuration);
            }
            else
            {
                Debug.Log("Revert");
            }    
        }
    }

    private void OnConfigurationFileChanged(AutomaticCISO configuration)
    {
        if(configuration == null)
            return;
        
        UpdateConfigurationContent(configuration);
        GenerateGitlabCIFile(configuration);
    }
    
    private void OnChangesApplied(AutomaticCISO configuration)
    {
        UpdateConfigurationContent(configuration);
        GenerateGitlabCIFile(configuration);
    }
    
    private void UpdateConfigurationContent(AutomaticCISO configuration)
    {
        if(_configurationContentView != null)
            _root.Remove(_configurationContentView);
        
        _configurationContentView = new ConfigurationContentView();
        _root.Add(_configurationContentView);
    }

    private void GenerateGitlabCIFile(AutomaticCISO configuration)
    {
        var builder = new AutomaticCIBuilder();
        
        if (configuration.editMode || configuration.playMode)
        {
            builder.WithTests(configuration.editMode, configuration.playMode);
        }

        foreach (BuildTarget platform in configuration.GetBuildPlatforms())
        {
            switch (platform)
            {
                case  BuildTarget.StandaloneWindows64:
                    builder.WithWindowsBuild();
                    break;
                
                case BuildTarget.Android:
                    builder.WithAndroidBuild();
                    break;
            }
        }
        
        builder.Save();
    }
}