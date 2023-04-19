<<<<<<< HEAD
﻿public abstract class Controller
{
    protected virtual void RegisterCallbacks() {}
    protected virtual void UnregisterCallbacks() {}

    public virtual void OnDestroy()
    {
        UnregisterCallbacks();
    }
=======
﻿public abstract class Controller
{
    protected virtual void RegisterCallbacks() {}
    protected virtual void UnregisterCallbacks() {}

    public virtual void OnDestroy()
    {
        UnregisterCallbacks();
    }
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}