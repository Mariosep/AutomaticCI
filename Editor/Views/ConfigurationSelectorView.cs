using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

public class ConfigurationSelectorView : View
{
    private readonly string visualTreeAssetPath = "Assets/Editor/UXML/ConfigurationSelector.uxml";

    public Action onCreateNewConfigurationButtonClicked;
    public Action<AutomaticCISO> onConfigurationObjectFieldChanged;    
    
    private Button _createNewConfigurationButton;
    private ObjectField _configurationObjectField;
    
    public ConfigurationSelectorView()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);

        SetVisualElements();
        RegisterCallbacks();
        
        controller = new ConfigurationSelectorController(this);
    }

    protected override void SetVisualElements()
    {
        _createNewConfigurationButton = this.Q<Button>("create-new-configuration__button");
        
        _configurationObjectField = this.Q<ObjectField>("configuration__object-field");
        _configurationObjectField.objectType = typeof(AutomaticCISO);
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _createNewConfigurationButton.clicked += ClickCreateNewConfigurationButton;
        _configurationObjectField.RegisterValueChangedCallback(evt => ChangeConfigurationObjectField(evt.newValue));
    }

    private void ClickCreateNewConfigurationButton() => onCreateNewConfigurationButtonClicked?.Invoke();
    
    public void ChangeConfigurationObjectField(Object newValue)
    {
        _configurationObjectField.value = newValue;
        AutomaticCISO configurationSelected = newValue as AutomaticCISO;
        onConfigurationObjectFieldChanged?.Invoke(configurationSelected);
    }

    public void ShowCreateNewConfigurationButton()
    {
        _createNewConfigurationButton.visible = true;
    }
    
    public void HideCreateNewConfigurationButton()
    {
        _createNewConfigurationButton.visible = false;
    }
}