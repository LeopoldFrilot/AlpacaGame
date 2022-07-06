using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHub
{
    public static event Action<PomodoroState> OnPomodoroStateSwitch;
    public static void TriggerPomodoroStateSwitch(PomodoroState newState)
    {
        OnPomodoroStateSwitch?.Invoke(newState);
    }

    /*
    public static event Action<PlayerCharacter> OnPlayerBirth;
    public static void TriggerPlayerBirth(PlayerCharacter character)
    {
        OnPlayerBirth?.Invoke(character);
    }

    public static event Action<ToroboCharacter> OnToroboBirth;
    public static void TriggerToroboBirth(ToroboCharacter character)
    {
        OnToroboBirth?.Invoke(character);
    }

    public static event Action<ToroboCharacter> OnToroboDeath;
    public static void TriggerToroboDeath(ToroboCharacter character)
    {
        OnToroboDeath?.Invoke(character);
    }

    public static event Action OnPause;
    public static void TriggerPause()
    {
        OnPause?.Invoke();
    }

    public static event Action OnResume;

    public static void TriggerResume()
    {
        OnResume?.Invoke();
    }

    public static event Action OnKeyPickup;
    public static void TriggerKeyCollected()
    {
        OnKeyPickup?.Invoke();
    }

    public static event Action<float> OnHealthPickup;
    public static void TriggerHealthCollected(float val)
    {
        OnHealthPickup?.Invoke(val);
    }

    public static event Action OnPlayerDodge;
    public static void TriggerPlayerDodge()
    {
        OnPlayerDodge?.Invoke();
    }

    public static event Action OnStartPressed;
    public static void TriggerStartPressed()
    {
        OnStartPressed?.Invoke();
    }

    public static event Action OnPerfectDodge;
    public static void TriggeredPerfectDodge()
    {
        OnPerfectDodge?.Invoke();
    }

    public static event Action<bool> OnDebugToggled;
    public static void TriggeredDebugModeToggle(bool toggleResult)
    {
        OnDebugToggled?.Invoke(toggleResult);
    }

    public static event Action OnSFXVolumeChanged;
    public static void TriggeredSFXVolumeChange()
    {
        OnSFXVolumeChanged?.Invoke();
    }

    public static event Action OnMusicVolumeChanged;
    public static void TriggeredMusicVolumeChange()
    {
        OnMusicVolumeChanged?.Invoke();
    }

    public static event Action OnGameStart;
    public static void TriggerGameStart()
    {
        OnGameStart?.Invoke();
    }

    public static event Action<float> OnScoreChanged;
    public static void TriggerScoreChanged(float score)
    {
        OnScoreChanged?.Invoke(score);
    }

    public static event Action<float> OnScoreUpdated;
    public static void TriggerScoreUpdated(float score)
    {
        OnScoreUpdated?.Invoke(score);
    }

    public static event Action<float> OnMultUpdated;
    public static void TriggerMultUpdated(float mult)
    {
        OnMultUpdated?.Invoke(mult);
    }
    */
}