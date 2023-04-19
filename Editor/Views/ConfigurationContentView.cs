<<<<<<< HEAD
﻿using UnityEditor;
using UnityEngine.UIElements;

public class ConfigurationContentView : View
{
    private readonly string visualTreeAssetPath = "Packages/com.mariosep.automatic-ci/Editor/UXML/ConfigurationContent.uxml";

    private VisualElement settings;
    private VisualElement persistence;
    
    // Views
    private UnitTestsView _unitTestsView;
    private BuildPlatformsView _buildPlatformsView;
    private PersistenceView _persistenceView;
    
    public ConfigurationContentView()
    {
        controller = new ConfigurationContentController(this);

        AddContent();
        
        style.flexGrow = 1;
    }

    protected override void SetVisualElements()
    {
        settings = this.Q<VisualElement>("settings");
        persistence = this.Q<VisualElement>("persistence");

        _unitTestsView = new UnitTestsView(); 
        _buildPlatformsView = new BuildPlatformsView(); 
        _persistenceView = new PersistenceView();
        
        settings.Add(_unitTestsView);
        settings.Add(_buildPlatformsView);
        persistence.Add(_persistenceView);
    }

    private void AddContent()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
        
        SetVisualElements();
    }

    /*public void Reset()
    {
        if(HasContent())
            RemoveContent();
        
        AddContent();
    }*/

    private void RemoveContent()
    {
        RemoveAt(0);
    }

    private bool HasContent() => childCount > 0;
    
    public void HideConfigurationContent() => this.visible = false;
    public void ShowConfigurationContent() => this.visible = true;
=======
﻿using UnityEditor;
using UnityEngine.UIElements;

public class ConfigurationContentView : View
{
    private readonly string visualTreeAssetPath = "Packages/com.mariosep.automatic-ci/Editor/UXML/ConfigurationContent.uxml";

    private VisualElement settings;
    private VisualElement persistence;
    
    // Views
    private UnitTestsView _unitTestsView;
    private BuildPlatformsView _buildPlatformsView;
    private PersistenceView _persistenceView;
    
    public ConfigurationContentView()
    {
        controller = new ConfigurationContentController(this);

        AddContent();
        
        style.flexGrow = 1;
    }

    protected override void SetVisualElements()
    {
        settings = this.Q<VisualElement>("settings");
        persistence = this.Q<VisualElement>("persistence");

        _unitTestsView = new UnitTestsView(); 
        _buildPlatformsView = new BuildPlatformsView(); 
        _persistenceView = new PersistenceView();
        
        settings.Add(_unitTestsView);
        settings.Add(_buildPlatformsView);
        persistence.Add(_persistenceView);
    }

    private void AddContent()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
        
        SetVisualElements();
    }

    /*public void Reset()
    {
        if(HasContent())
            RemoveContent();
        
        AddContent();
    }*/

    private void RemoveContent()
    {
        RemoveAt(0);
    }

    private bool HasContent() => childCount > 0;
    
    public void HideConfigurationContent() => this.visible = false;
    public void ShowConfigurationContent() => this.visible = true;
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}