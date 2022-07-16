using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroManager : MonoBehaviour
{
    public TimerUIController timerUIController;

    [Header("Sounds")]
    [SerializeField] private AudioClip pomoStartSound;
    [SerializeField][Range(0f,1f)] private float pomoStartSoundVolume;
    [SerializeField] private AudioClip breakStartSound;
    [SerializeField][Range(0f,1f)] private float breakStartSoundVolume;
    [SerializeField] private AudioClip timerOverSound;
    [SerializeField][Range(0f,1f)] private float timerOverSoundVolume;
    
    [SerializeField] bool hasLimit;
    [SerializeField] float timerLimit;
    
    [SerializeField] 

    bool timerStopped = true;
    float currentTime;
    PomodoroState currentState;

    private void Start()
    {
        currentState = PomodoroState.None;
        EventHub.TriggerPomodoroStateSwitch(currentState);
        FB.LogTestEvent();
    }

    void Update()
    {
        if (!timerStopped)
        {
            currentTime -= Time.deltaTime;
            if (hasLimit && currentTime <= timerLimit)
            {
                AudioHub.Instance.PlayClip(timerOverSound, timerOverSoundVolume);
                timerStopped = true;
                UpdatePomoState();
            }

            timerUIController.ChangeTime(currentTime, timerStopped);
        }
    }

    public void StartTimer()
    {
        if (currentState == PomodoroState.None || currentState == PomodoroState.Pomodoro)
        {
            AudioHub.Instance.PlayClip(pomoStartSound, pomoStartSoundVolume);
            StartNewCountdownTimer(timerUIController.GetPomodoroTimes().x, PomodoroState.Pomodoro); // Just 25 seconds for now
        }
        else if (currentState == PomodoroState.Break)
        {
            AudioHub.Instance.PlayClip(breakStartSound, breakStartSoundVolume);
            StartNewCountdownTimer(timerUIController.GetPomodoroTimes().y, PomodoroState.Break); // Just 5 seconds for now
        }
    }
    
    private void StartNewCountdownTimer(float time, PomodoroState state)
    {
        if (state == PomodoroState.None)
        {
            return;
        }
        currentTime = time;
        timerStopped = false;

        if (state != currentState)
        {
            currentState = state;
            EventHub.TriggerPomodoroStateSwitch(currentState);
        }
    }

    private void UpdatePomoState()
    {
        if (currentState == PomodoroState.Pomodoro)
        {
            currentState = PomodoroState.Break;
            EventHub.TriggerPomodoroStateSwitch(currentState);
        }
        else if (currentState == PomodoroState.Break)
        {
            currentState = PomodoroState.None;
            EventHub.TriggerPomodoroStateSwitch(currentState);
        }
    }
}
