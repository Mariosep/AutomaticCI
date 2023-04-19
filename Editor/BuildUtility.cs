<<<<<<< HEAD
﻿using System.Linq;
using UnityEditor;
using UnityEngine;

class BuildUtility
{
    [MenuItem("Build/Windows")]
    static void WindowsBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/Windows/AutomaticCI.exe",
            target = BuildTarget.StandaloneWindows
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem("Build/Android")]
    static void AndroidBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/Android/AutomaticCI.apk",
            target = BuildTarget.Android
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
    
    [MenuItem("Build/WebGL")]
    static void WebGLBuild()
    {
        ColorSpace previousColorSpace = PlayerSettings.colorSpace;
        
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/WebGL/AutomaticCI.apk",
            target = BuildTarget.WebGL
        };
        PlayerSettings.colorSpace = ColorSpace.Gamma;
        
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        PlayerSettings.colorSpace = previousColorSpace;
    }

    static string[] GetEnabledScenes()
    {
        return (
            from scene in EditorBuildSettings.scenes
            where scene.enabled
            where !string.IsNullOrEmpty(scene.path)
            select scene.path
        ).ToArray();
    }
=======
﻿using System.Linq;
using UnityEditor;
using UnityEngine;

class BuildUtility
{
    [MenuItem("Build/Windows")]
    static void WindowsBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/Windows/AutomaticCI.exe",
            target = BuildTarget.StandaloneWindows
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem("Build/Android")]
    static void AndroidBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/Android/AutomaticCI.apk",
            target = BuildTarget.Android
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
    
    [MenuItem("Build/WebGL")]
    static void WebGLBuild()
    {
        ColorSpace previousColorSpace = PlayerSettings.colorSpace;
        
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = "Build/WebGL/AutomaticCI.apk",
            target = BuildTarget.WebGL
        };
        PlayerSettings.colorSpace = ColorSpace.Gamma;
        
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        PlayerSettings.colorSpace = previousColorSpace;
    }

    static string[] GetEnabledScenes()
    {
        return (
            from scene in EditorBuildSettings.scenes
            where scene.enabled
            where !string.IsNullOrEmpty(scene.path)
            select scene.path
        ).ToArray();
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}