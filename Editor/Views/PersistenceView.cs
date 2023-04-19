<<<<<<< HEAD
﻿using System;
using UnityEditor;
using UnityEngine.UIElements;

public class PersistenceView : View
{
    private readonly string visualTreeAssetPath = "Packages/com.mariosep.automatic-ci/Editor/UXML/Persistence.uxml";

    public Action onRevertButtonClicked;
    public Action onApplyButtonClicked;
    
    private Button _revertButton;
    private Button _applyButton;

    public PersistenceView()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
        
        SetVisualElements();
        RegisterCallbacks();

        controller = new PersistenceController(this);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        
        _revertButton = this.Q<Button>("revert-button");
        _applyButton = this.Q<Button>("apply-button");
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _revertButton.clicked += OnRevertButtonClicked;
        _applyButton.clicked += OnApplyButtonClicked;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _revertButton.clicked -= OnRevertButtonClicked;
        _applyButton.clicked -= OnApplyButtonClicked;
    }

    private void OnRevertButtonClicked() => onRevertButtonClicked?.Invoke();
    private void OnApplyButtonClicked() => onApplyButtonClicked?.Invoke();

    public void EnablePersistenceButtons()
    {
        _revertButton.SetEnabled(true);
        _applyButton.SetEnabled(true);
    }

    public void DisablePersistenceButtons()
    {
        _revertButton.SetEnabled(false);
        _applyButton.SetEnabled(false);
    }
=======
﻿using System;
using UnityEditor;
using UnityEngine.UIElements;

public class PersistenceView : View
{
    private readonly string visualTreeAssetPath = "Packages/com.mariosep.automatic-ci/Editor/UXML/Persistence.uxml";

    public Action onRevertButtonClicked;
    public Action onApplyButtonClicked;
    
    private Button _revertButton;
    private Button _applyButton;

    public PersistenceView()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
        
        SetVisualElements();
        RegisterCallbacks();

        controller = new PersistenceController(this);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        
        _revertButton = this.Q<Button>("revert-button");
        _applyButton = this.Q<Button>("apply-button");
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _revertButton.clicked += OnRevertButtonClicked;
        _applyButton.clicked += OnApplyButtonClicked;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _revertButton.clicked -= OnRevertButtonClicked;
        _applyButton.clicked -= OnApplyButtonClicked;
    }

    private void OnRevertButtonClicked() => onRevertButtonClicked?.Invoke();
    private void OnApplyButtonClicked() => onApplyButtonClicked?.Invoke();

    public void EnablePersistenceButtons()
    {
        _revertButton.SetEnabled(true);
        _applyButton.SetEnabled(true);
    }

    public void DisablePersistenceButtons()
    {
        _revertButton.SetEnabled(false);
        _applyButton.SetEnabled(false);
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}