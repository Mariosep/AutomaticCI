<<<<<<< HEAD
﻿using UnityEditor;
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
=======
﻿using UnityEditor;
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
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}