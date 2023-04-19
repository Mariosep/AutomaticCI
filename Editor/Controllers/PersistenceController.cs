<<<<<<< HEAD
﻿using UnityEditor;
using UnityEngine;

public class PersistenceController : Controller
{
    private static bool _hasUnappliedChanges;
    public static bool HasUnappliedChanges => _hasUnappliedChanges;
    
    private PersistenceView _view;

    private AutomaticCISO _configuration;
    private AutomaticCISO _configurationTmp;
    
    public PersistenceController(PersistenceView view)
    {
        _view = view;

        _configuration = AutomaticCISettings.instance.Configuration;
        _configurationTmp = ConfigurationContentController.ConfigurationTmp;
        
        RegisterCallbacks();
        
        CheckConfigDataEquality();
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();

        _view.onRevertButtonClicked += RevertChanges;
        _view.onApplyButtonClicked += ApplyChanges;
        _configurationTmp.onDataChanged += CheckConfigDataEquality;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _view.onRevertButtonClicked -= RevertChanges;
        _view.onApplyButtonClicked -= ApplyChanges;
        _configurationTmp.onDataChanged -= CheckConfigDataEquality;
    }
    
    private void CheckConfigDataEquality()
    {
        if (_configuration != null && _configuration.Equals(_configurationTmp))
        {
            _view.DisablePersistenceButtons();

            _hasUnappliedChanges = false;
        }
        else
        {
            _view.EnablePersistenceButtons();
            
            _hasUnappliedChanges = true;
        }
    }

    private void RevertChanges()
    {
        PersistenceUtility.Copy(_configuration, _configurationTmp);
        /*var json = JsonUtility.ToJson(_configuration);
        JsonUtility.FromJsonOverwrite(json, _configurationTmp);*/
        
        CheckConfigDataEquality();
        
        EventBus.onChangesReverted?.Invoke(_configuration);
    }

    private void ApplyChanges()
    {
        PersistenceUtility.Copy(_configurationTmp, _configuration);
        /*var json = JsonUtility.ToJson(_configurationTmp);
        JsonUtility.FromJsonOverwrite(json, _configuration);

        EditorUtility.SetDirty(_configuration);*/
        
        CheckConfigDataEquality();
        
        EventBus.onChangesApplied?.Invoke(_configuration);
    }
}

public static class PersistenceUtility
{
    public static void Copy(Object objectToCopy, Object objectToChange)
    {
        var json = JsonUtility.ToJson(objectToCopy);
        JsonUtility.FromJsonOverwrite(json, objectToChange);

        EditorUtility.SetDirty(objectToChange);
    }
=======
﻿using UnityEditor;
using UnityEngine;

public class PersistenceController : Controller
{
    private static bool _hasUnappliedChanges;
    public static bool HasUnappliedChanges => _hasUnappliedChanges;
    
    private PersistenceView _view;

    private AutomaticCISO _configuration;
    private AutomaticCISO _configurationTmp;
    
    public PersistenceController(PersistenceView view)
    {
        _view = view;

        _configuration = AutomaticCISettings.instance.Configuration;
        _configurationTmp = ConfigurationContentController.ConfigurationTmp;
        
        RegisterCallbacks();
        
        CheckConfigDataEquality();
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();

        _view.onRevertButtonClicked += RevertChanges;
        _view.onApplyButtonClicked += ApplyChanges;
        _configurationTmp.onDataChanged += CheckConfigDataEquality;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _view.onRevertButtonClicked -= RevertChanges;
        _view.onApplyButtonClicked -= ApplyChanges;
        _configurationTmp.onDataChanged -= CheckConfigDataEquality;
    }
    
    private void CheckConfigDataEquality()
    {
        if (_configuration != null && _configuration.Equals(_configurationTmp))
        {
            _view.DisablePersistenceButtons();

            _hasUnappliedChanges = false;
        }
        else
        {
            _view.EnablePersistenceButtons();
            
            _hasUnappliedChanges = true;
        }
    }

    private void RevertChanges()
    {
        PersistenceUtility.Copy(_configuration, _configurationTmp);
        /*var json = JsonUtility.ToJson(_configuration);
        JsonUtility.FromJsonOverwrite(json, _configurationTmp);*/
        
        CheckConfigDataEquality();
        
        EventBus.onChangesReverted?.Invoke(_configuration);
    }

    private void ApplyChanges()
    {
        PersistenceUtility.Copy(_configurationTmp, _configuration);
        /*var json = JsonUtility.ToJson(_configurationTmp);
        JsonUtility.FromJsonOverwrite(json, _configuration);

        EditorUtility.SetDirty(_configuration);*/
        
        CheckConfigDataEquality();
        
        EventBus.onChangesApplied?.Invoke(_configuration);
    }
}

public static class PersistenceUtility
{
    public static void Copy(Object objectToCopy, Object objectToChange)
    {
        var json = JsonUtility.ToJson(objectToCopy);
        JsonUtility.FromJsonOverwrite(json, objectToChange);

        EditorUtility.SetDirty(objectToChange);
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}