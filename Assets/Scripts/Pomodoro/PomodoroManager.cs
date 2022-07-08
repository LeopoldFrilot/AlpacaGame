using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroManager : MonoBehaviour
{
    public TimerUIController timerUIController;

    [SerializeField] bool hasLimit;
    [SerializeField] float timerLimit;

    bool timerStopped = true;
    float currentTime;
    PomodoroState currentState;

    private void Start()
    {
        currentState = PomodoroState.None;
        EventHub.Instance.TriggerPomodoroStateSwitch(currentState);
    }

    void Update()
    {
        if (!timerStopped)
        {
            currentTime -= Time.deltaTime;
            if (hasLimit && currentTime <= timerLimit)
            {
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
            StartNewCountdownTimer(/*Helper.MinutesToSeconds(25)*/ 25f, PomodoroState.Pomodoro); // Just 25 seconds for now
        }
        else if (currentState == PomodoroState.Break)
        {
            StartNewCountdownTimer(/*Helper.MinutesToSeconds(5)*/ 5f, PomodoroState.Break); // Just 5 seconds for now
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
            EventHub.Instance.TriggerPomodoroStateSwitch(currentState);
        }
    }

    private void UpdatePomoState()
    {
        if (currentState == PomodoroState.Pomodoro)
        {
            currentState = PomodoroState.Break;
            EventHub.Instance.TriggerPomodoroStateSwitch(currentState);
        }
        else if (currentState == PomodoroState.Break)
        {
            currentState = PomodoroState.None;
            EventHub.Instance.TriggerPomodoroStateSwitch(currentState);
        }
    }
}
