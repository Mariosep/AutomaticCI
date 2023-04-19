using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class ConfigurationContentController : Controller
{
    public static AutomaticCISO ConfigurationTmp { get; set; }
    
    private ConfigurationContentView _view;

    private AutomaticCISO _configuration;
    private AutomaticCISO _configurationTemp;

    public ConfigurationContentController(ConfigurationContentView view)
    {
        _view = view;
        
        RegisterCallbacks();
        
        UpdateConfigurationContent(AutomaticCISettings.instance.Configuration);
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();

        EventBus.onConfigurationFileChanged += UpdateConfigurationContent;
        EventBus.onChangesReverted += UpdateConfigurationContent;
        EventBus.onChangesApplied += UpdateConfigurationContent;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        EventBus.onConfigurationFileChanged -= UpdateConfigurationContent;
        EventBus.onChangesReverted -= UpdateConfigurationContent;
        EventBus.onChangesApplied -= UpdateConfigurationContent;
    }

    private void UpdateConfigurationContent(AutomaticCISO configuration)
    {
        _view.Unbind();

        _configuration = configuration;
        
        if(_configuration == null)
            _view.HideConfigurationContent();
        else
        {
            _configurationTemp = ScriptableObject.Instantiate(configuration);
            
            ConfigurationTmp = _configurationTemp;
            
            _view.Bind(new SerializedObject(_configurationTemp));
            
            _view.ShowConfigurationContent();
        }
    }
}