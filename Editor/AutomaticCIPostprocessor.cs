using System;
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
}