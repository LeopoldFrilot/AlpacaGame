using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHub : MonoBehaviour
{
    #region Singleton
    private static EventHub _instance;
    public static EventHub Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("EventHub");
                gO.AddComponent<EventHub>().Awake();
            }
            return _instance;
        }
    }


    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public event Action<PomodoroState> OnPomodoroStateSwitch;
    public void TriggerPomodoroStateSwitch(PomodoroState newState)
    {
        OnPomodoroStateSwitch?.Invoke(newState);
    }

    public event Action OnMusicVolumeChanged;
    public void TriggerMusicVolumeChanged()
    {
        OnMusicVolumeChanged?.Invoke();
    }

    public event Action OnSFXVolumeChanged;
    public void TriggerSFXVolumeChanged()
    {
        OnSFXVolumeChanged?.Invoke();
    }
}