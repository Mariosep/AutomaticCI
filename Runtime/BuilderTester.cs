using UnityEditor;
using UnityEngine;

public class BuilderTester : MonoBehaviour
{
    [SerializeField] private AutomaticCISO configuration;
    
    [ContextMenu("BuildAutomaticCIFile")]
    public void BuildAutomaticCIFile()
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