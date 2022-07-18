using System;

public static class EventHub
{
    public static event Action<PomodoroState> OnPomodoroStateSwitch;
    public static void TriggerPomodoroStateSwitch(PomodoroState newState)
    {
        OnPomodoroStateSwitch?.Invoke(newState);
    }

    public static event Action OnMusicVolumeChanged;
    public static void TriggerMusicVolumeChanged()
    {
        OnMusicVolumeChanged?.Invoke();
    }

    public static event Action OnSFXVolumeChanged;
    public static void TriggerSFXVolumeChanged()
    {
        OnSFXVolumeChanged?.Invoke();
    }
    
    public static event Action OnTimerForceEnd;
    public static void TriggerTimerForceEnd()
    {
        OnTimerForceEnd?.Invoke();
    }
}