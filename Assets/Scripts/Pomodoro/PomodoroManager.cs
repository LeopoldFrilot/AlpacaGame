using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroManager : MonoBehaviour
{
    /* TEMPORARY LOGIC: PLEASE REWORK */
    public TimerController timerController;
    bool timerStopped = true;

    void Awake()
    {
        // Initializing timer to 5 seconds just for testing
        timerController.currentTime = 5f;
        timerController.countDown = true;
        timerController.enabled = true;
        timerController.timerLimit = 0f;
    }

    void Update()
    {
        if (!timerStopped && !timerController.enabled) // Temporary timer-end condition
        {
            timerStopped = true;
        }
    }

    public void StartNewCountdownTimer(float time)
    {
        timerController.currentTime = time;
        timerController.countDown = true;
        timerController.enabled = true;
        timerController.timerLimit = 0f;
    }
}
