using System;
using UnityEngine;

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
    
    public static event Action<Vector2> OnClickDown;
    public static void TriggerClickDown(Vector2 clickLocation)
    {
        OnClickDown?.Invoke(clickLocation);
    }
    
    public static event Action<int> OnPomodoroEnded;
    public static void TriggerPomodoroEnded(int originalTimeInMinutes)
    {
        OnPomodoroEnded?.Invoke(originalTimeInMinutes);
    }

    public static event Action<CropRoot> OnCropHarvested;
    public static void TriggerCropHarvested(CropRoot crop)
    {
        OnCropHarvested?.Invoke(crop);
    }

    public static event Action<CropSO> OnCropSeedSelected;
    public static void TriggerCropSeedSelected(CropSO crop)
    {
        OnCropSeedSelected?.Invoke(crop);
    }

    public static event Action<CropSO> OnCropSeedCountChanged;
    public static void TriggerCropSeedCountChanged(CropSO crop)
    {
        OnCropSeedCountChanged?.Invoke(crop);
    }

    public static event Action<int> OnSolesCountChanged;
    public static void TriggerSolesCountChanged(int newValue)
    {
        OnSolesCountChanged?.Invoke(newValue);
    }

    public static event Action<int> OnCoinsCountChanged;
    public static void TriggerCoinsCountChanged(int newValue)
    {
        OnCoinsCountChanged?.Invoke(newValue);
    }
}