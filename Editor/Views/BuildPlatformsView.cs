using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

public class BuildPlatformsView : View
{
    public new class UxmlFactory : UxmlFactory<BuildPlatformsView, UxmlTraits> {}
    
    private readonly string visualTreeAssetPath = "Assets/Editor/UXML/BuildPlatforms.uxml";

    public Action<BuildTarget> onBuildPlatformSelected;
    public Action<BuildTarget> onBuildPlatformUnselected;

    private VisualElement _buildPlatformsContainer;
    
    private List<BuildPlatformBoxView> _buildPlatformsBoxViews;
    
    public BuildPlatformsView()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
        
        SetVisualElements();
        RegisterCallbacks();

        controller = new BuildPlatformsController(this);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        _buildPlatformsContainer = this.Q<VisualElement>("build-platforms__content");
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        BuildPlatformBoxView.onSelect += OnBuildPlatformSelected;
        BuildPlatformBoxView.onUnselect += OnBuildPlatformUnselected;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        BuildPlatformBoxView.onSelect -= OnBuildPlatformSelected;
        BuildPlatformBoxView.onUnselect -= OnBuildPlatformUnselected;
    }
    
    public void GenerateBuildPlatformsBoxViews(List<BuildTarget> buildPlatforms, List<BuildTarget> buildPlatformsSelected)
    {
        _buildPlatformsBoxViews = new List<BuildPlatformBoxView>();
        
        foreach (var buildPlatform in buildPlatforms)
        {
            var box = new BuildPlatformBoxView(buildPlatform);
            if(buildPlatformsSelected.Contains(buildPlatform))
                box.SetSelection(true);
            
            _buildPlatformsBoxViews.Add(box);
            _buildPlatformsContainer.Add(box);
        }
    }

    private void OnBuildPlatformSelected(BuildPlatformBoxView box)
    {
        onBuildPlatformSelected?.Invoke(box.BuildTarget);
    }
    
    private void OnBuildPlatformUnselected(BuildPlatformBoxView box)
    {
        onBuildPlatformUnselected?.Invoke(box.BuildTarget);
    }
}