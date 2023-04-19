<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "config", menuName = "AutomaticCI/Configuration")]
public class AutomaticCISO : ScriptableObject
{
    public Action onDataChanged;
    
    [Header("Unit tests")]
    [SerializeField] public bool editMode;
    [SerializeField] public bool playMode;
    
    [Header("Build platforms")]
    [SerializeField] private List<BuildTarget> buildPlatforms = new List<BuildTarget>();

    public void AddBuildPlatform(BuildTarget buildTarget)
    {
        if (!buildPlatforms.Contains(buildTarget))
        {
            buildPlatforms.Add(buildTarget);
            OnValidate();    
        }
    }

    public void RemoveBuildPlatform(BuildTarget buildTarget)
    {
        if (buildPlatforms.Contains(buildTarget))
        {
            buildPlatforms.Remove(buildTarget);
            OnValidate();    
        }
    }

    public List<BuildTarget> GetBuildPlatforms() => buildPlatforms;

    private void OnValidate()
    {
        onDataChanged?.Invoke();
    }
    
    public override bool Equals(object other)
    {
        if (other is AutomaticCISO otherData)
        {
            if (editMode != otherData.editMode || playMode != otherData.playMode)
                return false;
            if (!buildPlatforms.SequenceEqual(otherData.buildPlatforms))
                return false;

            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "config", menuName = "AutomaticCI/Configuration")]
public class AutomaticCISO : ScriptableObject
{
    public Action onDataChanged;
    
    [Header("Unit tests")]
    [SerializeField] public bool editMode;
    [SerializeField] public bool playMode;
    
    [Header("Build platforms")]
    [SerializeField] private List<BuildTarget> buildPlatforms = new List<BuildTarget>();

    public void AddBuildPlatform(BuildTarget buildTarget)
    {
        if (!buildPlatforms.Contains(buildTarget))
        {
            buildPlatforms.Add(buildTarget);
            OnValidate();    
        }
    }

    public void RemoveBuildPlatform(BuildTarget buildTarget)
    {
        if (buildPlatforms.Contains(buildTarget))
        {
            buildPlatforms.Remove(buildTarget);
            OnValidate();    
        }
    }

    public List<BuildTarget> GetBuildPlatforms() => buildPlatforms;

    private void OnValidate()
    {
        onDataChanged?.Invoke();
    }
    
    public override bool Equals(object other)
    {
        if (other is AutomaticCISO otherData)
        {
            if (editMode != otherData.editMode || playMode != otherData.playMode)
                return false;
            if (!buildPlatforms.SequenceEqual(otherData.buildPlatforms))
                return false;

            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}