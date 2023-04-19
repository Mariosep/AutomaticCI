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
}