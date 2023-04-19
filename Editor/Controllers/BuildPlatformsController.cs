<<<<<<< HEAD
﻿using System.Collections.Generic;
using UnityEditor;

public class BuildPlatformsController : Controller
{
    private BuildPlatformsView _view;

    private AutomaticCISO _configurationTmp;
    
    public List<BuildTarget> buildPlatforms = new List<BuildTarget>()
    {
        BuildTarget.StandaloneWindows64,
        BuildTarget.StandaloneLinux64,
        BuildTarget.Android
    };
    
    public BuildPlatformsController(BuildPlatformsView view)
    {
        _view = view;

        RegisterCallbacks();

        _configurationTmp = ConfigurationContentController.ConfigurationTmp;
        
        _view.GenerateBuildPlatformsBoxViews(buildPlatforms, _configurationTmp.GetBuildPlatforms());
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _view.onBuildPlatformSelected += AddBuildPlatform;
        _view.onBuildPlatformUnselected += RemoveBuildPlatform;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _view.onBuildPlatformSelected -= AddBuildPlatform;
        _view.onBuildPlatformUnselected -= RemoveBuildPlatform;
    }

    private void AddBuildPlatform(BuildTarget buildTarget)
    {
        _configurationTmp.AddBuildPlatform(buildTarget);
    }
    
    private void RemoveBuildPlatform(BuildTarget buildTarget)
    {
        _configurationTmp.RemoveBuildPlatform(buildTarget);
    }
=======
﻿using System.Collections.Generic;
using UnityEditor;

public class BuildPlatformsController : Controller
{
    private BuildPlatformsView _view;

    private AutomaticCISO _configurationTmp;
    
    public List<BuildTarget> buildPlatforms = new List<BuildTarget>()
    {
        BuildTarget.StandaloneWindows64,
        BuildTarget.StandaloneLinux64,
        BuildTarget.Android
    };
    
    public BuildPlatformsController(BuildPlatformsView view)
    {
        _view = view;

        RegisterCallbacks();

        _configurationTmp = ConfigurationContentController.ConfigurationTmp;
        
        _view.GenerateBuildPlatformsBoxViews(buildPlatforms, _configurationTmp.GetBuildPlatforms());
    }

    protected override void RegisterCallbacks()
    {
        base.RegisterCallbacks();
        
        _view.onBuildPlatformSelected += AddBuildPlatform;
        _view.onBuildPlatformUnselected += RemoveBuildPlatform;
    }

    protected override void UnregisterCallbacks()
    {
        base.UnregisterCallbacks();
        
        _view.onBuildPlatformSelected -= AddBuildPlatform;
        _view.onBuildPlatformUnselected -= RemoveBuildPlatform;
    }

    private void AddBuildPlatform(BuildTarget buildTarget)
    {
        _configurationTmp.AddBuildPlatform(buildTarget);
    }
    
    private void RemoveBuildPlatform(BuildTarget buildTarget)
    {
        _configurationTmp.RemoveBuildPlatform(buildTarget);
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}