<<<<<<< HEAD
﻿using System;
using UnityEditor;

public class AutomaticCIPostprocessor : AssetPostprocessor
{
    public static Action onAutomaticCIDataDeleted;
    
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
    {
        foreach (string str in deletedAssets)
        {
            if(AutomaticCISettings.instance.configurationPath == str)
                onAutomaticCIDataDeleted?.Invoke();
        }
    }
=======
﻿using System;
using UnityEditor;

public class AutomaticCIPostprocessor : AssetPostprocessor
{
    public static Action onAutomaticCIDataDeleted;
    
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
    {
        foreach (string str in deletedAssets)
        {
            if(AutomaticCISettings.instance.configurationPath == str)
                onAutomaticCIDataDeleted?.Invoke();
        }
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}