using UnityEngine;

public class PomodoroManager : MonoBehaviour
{
    public TimerUIController timerUIController;
    public GameSO gameData;
    [SerializeField] bool hasLimit;
    [SerializeField] float timerLimit;

    bool timerStopped = true;

    private float startingTimeInMinutes;
    float currentTimeInSeconds;
    PomodoroState currentState;

    private void Start()
    {
        currentState = PomodoroState.None;
        EventHub.TriggerPomodoroStateSwitch(currentState);
        FB.LogTestEvent();
    }

    public PomodoroState GetState()
    {
        return currentState;
    }

    void Update()
    {
        if (!timerStopped)
        {
            currentTimeInSeconds -= Time.deltaTime;
            if (hasLimit && currentTimeInSeconds <= timerLimit)
            {
                timerStopped = true;
                if (currentState == PomodoroState.Pomodoro)
                {
                    AudioHub.Instance.PlayClip(gameData.pomodoroEndSound, gameData.pomodoroEndSoundVolume);
                    EventHub.TriggerPomodoroEnded(startingTimeInMinutes);
                }
                else if (currentState == PomodoroState.Break)
                {
                    AudioHub.Instance.PlayClip(gameData.breakEndSound, gameData.breakEndSoundVolume);
                }
                UpdatePomoState();
            }

            timerUIController.ChangeTime(currentTimeInSeconds, timerStopped);
        }
    }

    public void StartTimer()
    {
        if (currentState == PomodoroState.None || currentState == PomodoroState.Pomodoro)
        {
            AudioHub.Instance.PlayClip(gameData.pomodoroStartSound, gameData.pomodoroEndSoundVolume);
            StartNewCountdownTimer(timerUIController.GetPomodoroTimes().x, PomodoroState.Pomodoro);
        }
        else if (currentState == PomodoroState.Break)
        {
            AudioHub.Instance.PlayClip(gameData.breakStartSound, gameData.breakStartSoundVolume);
            StartNewCountdownTimer(timerUIController.GetPomodoroTimes().y, PomodoroState.Break);
        }
    }
    
    private void StartNewCountdownTimer(float timeInSeconds, PomodoroState state)
    {
        if (state == PomodoroState.None)
        {
            return;
        }
        currentTimeInSeconds = timeInSeconds;
        startingTimeInMinutes = Helper.SecondsToMinutes(currentTimeInSeconds);
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

    private void EndTimer()
    {
        if (!timerStopped)
        {
            currentTimeInSeconds = 0f;
        }
    }

    private void OnEnable()
    {
        EventHub.OnTimerForceEnd += EndTimer;
    }

    private void OnDisable()
    {
        EventHub.OnTimerForceEnd -= EndTimer;
    }
}
