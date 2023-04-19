<<<<<<< HEAD
using UnityEngine.UIElements;

public abstract class View : VisualElement
{
    protected Controller controller;
    
    protected virtual void SetVisualElements() {}

    protected virtual void RegisterCallbacks()
    {
        RegisterCallback<DetachFromPanelEvent>((evt) => OnDestroy());
    }

    protected virtual void UnregisterCallbacks() {}
    
    protected virtual void OnDestroy()
    {
        UnregisterCallbacks();
        
        controller.OnDestroy();
    }
=======
using UnityEngine.UIElements;

public abstract class View : VisualElement
{
    protected Controller controller;
    
    protected virtual void SetVisualElements() {}

    protected virtual void RegisterCallbacks()
    {
        RegisterCallback<DetachFromPanelEvent>((evt) => OnDestroy());
    }

    protected virtual void UnregisterCallbacks() {}
    
    protected virtual void OnDestroy()
    {
        UnregisterCallbacks();
        
        controller.OnDestroy();
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}