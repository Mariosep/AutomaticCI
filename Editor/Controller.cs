public abstract class Controller
{
    protected virtual void RegisterCallbacks() {}
    protected virtual void UnregisterCallbacks() {}

    public virtual void OnDestroy()
    {
        UnregisterCallbacks();
    }
}