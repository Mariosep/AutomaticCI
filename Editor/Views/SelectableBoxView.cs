<<<<<<< HEAD
﻿using UnityEditor;
using UnityEngine.UIElements;

public class SelectableBoxView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<SelectableBoxView, UxmlTraits> {}

    private bool isSelected;

    private const string styleResource = "SelectableBoxStyleSheet";  
    
    private const string selectedStyle = "selectable_box-selected";
    private const string unselectedStyle = "selectable_box-unselected";

    public SelectableBoxView()
    {
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"Packages/com.mariosep.automatic-ci/Editor/USS/{styleResource}.uss");
        styleSheets.Add(styleSheet);
        
        AddToClassList(unselectedStyle);
        
        this.RegisterCallback<ClickEvent>(OnClick);
    }

    private void OnClick(ClickEvent eventData)
    {
        isSelected = !isSelected;

        if (isSelected)
            OnSelected();
        else
            OnUnselected();
    }

    public void SetSelection(bool selected)
    {
        isSelected = selected;
        
        if (isSelected)
            OnSelected();
        else
            OnUnselected();
    }
    
    protected virtual void OnSelected()
    {
        RemoveFromClassList(unselectedStyle);
        AddToClassList(selectedStyle);
    }
    
    protected virtual void OnUnselected()
    {
        RemoveFromClassList(selectedStyle);
        AddToClassList(unselectedStyle);
    }
}
=======
﻿using UnityEditor;
using UnityEngine.UIElements;

public class SelectableBoxView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<SelectableBoxView, UxmlTraits> {}

    private bool isSelected;

    private const string styleResource = "SelectableBoxStyleSheet";  
    
    private const string selectedStyle = "selectable_box-selected";
    private const string unselectedStyle = "selectable_box-unselected";

    public SelectableBoxView()
    {
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"Packages/com.mariosep.automatic-ci/Editor/USS/{styleResource}.uss");
        styleSheets.Add(styleSheet);
        
        AddToClassList(unselectedStyle);
        
        this.RegisterCallback<ClickEvent>(OnClick);
    }

    private void OnClick(ClickEvent eventData)
    {
        isSelected = !isSelected;

        if (isSelected)
            OnSelected();
        else
            OnUnselected();
    }

    public void SetSelection(bool selected)
    {
        isSelected = selected;
        
        if (isSelected)
            OnSelected();
        else
            OnUnselected();
    }
    
    protected virtual void OnSelected()
    {
        RemoveFromClassList(unselectedStyle);
        AddToClassList(selectedStyle);
    }
    
    protected virtual void OnUnselected()
    {
        RemoveFromClassList(selectedStyle);
        AddToClassList(unselectedStyle);
    }
}
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
