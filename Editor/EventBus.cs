using System;

public static class EventBus
{
    public static Action<AutomaticCISO> onConfigurationFileChanged;
    public static Action<AutomaticCISO> onChangesReverted;
    public static Action<AutomaticCISO> onChangesApplied;
}