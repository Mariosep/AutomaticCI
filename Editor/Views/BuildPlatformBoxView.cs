using System;
using UnityEditor;
using UnityEngine.UIElements;

public class BuildPlatformBoxView : SelectableBoxView
{
    private BuildTarget _buildTarget;
    private Label _label;
    
    public static Action<BuildPlatformBoxView> onSelect;
    public static Action<BuildPlatformBoxView> onUnselect;
    
    public BuildTarget BuildTarget => _buildTarget;
    
    public BuildPlatformBoxView(BuildTarget buildTarget)
    {
        _label = new Label();
        Add(_label);
        
        SetBuildTarget(buildTarget);
    }

    public void SetBuildTarget(BuildTarget buildTarget)
    {
        _buildTarget = buildTarget;
        
        string buildPlatformName;
        
        switch (buildTarget)
        {
            case BuildTarget.StandaloneWindows64:
                buildPlatformName = "Windows";
                break;
            
            case BuildTarget.StandaloneLinux64:
                buildPlatformName = "Linux";
                break;
                
            case BuildTarget.Android:
                buildPlatformName = "Android";
                break;
            
            default:
                buildPlatformName = "Default";
                break;
        }
        
        _label.text = buildPlatformName;
    }
    
    protected override void OnSelected()
    {
        base.OnSelected();
        onSelect?.Invoke(this);
    }

    protected override void OnUnselected()
    {
        base.OnUnselected();
        onUnselect?.Invoke(this);
    }
}