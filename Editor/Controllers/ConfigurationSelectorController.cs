using System.IO;
using UnityEditor;
using UnityEngine;

public class ConfigurationSelectorController : Controller
{
    private ConfigurationSelectorView _view;

    private AutomaticCISO _configuration;
    
    public ConfigurationSelectorController(ConfigurationSelectorView view)
    {
        _view = view;
        
        RegisterCallbacks();
        
        _configuration = AutomaticCISettings.instance.Configuration;
        
        if(_configuration != null)
            view.ChangeConfigurationObjectField(_configuration);
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _view.onCreateNewConfigurationButtonClicked += CreateNewConfiguration;
        _view.onConfigurationObjectFieldChanged += ChangeConfigurationFile;
        AutomaticCIPostprocessor.onAutomaticCIDataDeleted += ClearConfiguration;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _view.onCreateNewConfigurationButtonClicked -= CreateNewConfiguration;
        _view.onConfigurationObjectFieldChanged -= ChangeConfigurationFile;
        AutomaticCIPostprocessor.onAutomaticCIDataDeleted -= ClearConfiguration;
    }

    private void CreateNewConfiguration()
    {
        var newConfiguration = ScriptableObject.CreateInstance<AutomaticCISO>();

        string assetPath = "Assets/AutomaticCI/";
        
        string[] configNames = AssetDatabase.FindAssets("config", new[] { assetPath });
        string assetName = "config";
        if (configNames.Length > 0)
            assetName += $" {configNames.Length}";

        if (!Directory.Exists(assetPath))
            AssetDatabase.CreateFolder("Assets", "AutomaticCI");
        
        AssetDatabase.CreateAsset(newConfiguration, $"{assetPath}{assetName}.asset");

        _view.ChangeConfigurationObjectField(newConfiguration);
    }
    
    private void ChangeConfigurationFile(AutomaticCISO newConfiguration)
    {
        if (newConfiguration != null)
            _view.HideCreateNewConfigurationButton();
        else
            _view.ShowCreateNewConfigurationButton();

        AutomaticCISettings.instance.Configuration = newConfiguration;
        
        EventBus.onConfigurationFileChanged?.Invoke(newConfiguration);
    }
    
    private void ClearConfiguration()
    {
        _view.ChangeConfigurationObjectField(null);
    }
}