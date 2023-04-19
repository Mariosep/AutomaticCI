<<<<<<< HEAD
﻿using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/AutomaticCISettings.asset", FilePathAttribute.Location.ProjectFolder)]
public class AutomaticCISettings : ScriptableSingleton<AutomaticCISettings>
{
    [SerializeField] private AutomaticCISO _configuration;

    public string configurationPath;
    
    public AutomaticCISO Configuration
    {
        get => _configuration;
        set
        {
            _configuration = value;
            configurationPath = _configuration != null ? AssetDatabase.GetAssetPath(_configuration) : "";
            Save(true);
        }
    }
=======
﻿using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/AutomaticCISettings.asset", FilePathAttribute.Location.ProjectFolder)]
public class AutomaticCISettings : ScriptableSingleton<AutomaticCISettings>
{
    [SerializeField] private AutomaticCISO _configuration;

    public string configurationPath;
    
    public AutomaticCISO Configuration
    {
        get => _configuration;
        set
        {
            _configuration = value;
            configurationPath = _configuration != null ? AssetDatabase.GetAssetPath(_configuration) : "";
            Save(true);
        }
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}