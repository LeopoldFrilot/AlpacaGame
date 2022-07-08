using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

///<summary>
/// This class manages the controls for the pomotimer
///</summary>
public class TimerUIController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;

    [Header("FormatSettings")]
    [SerializeField] bool hasFormat;
    [SerializeField] TimerFormats format;
    //timerFormats is an object that controls the format once its selected
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    public void ChangeTime(float time, bool isFinished)
    {
        SetTimerText(time);
        if (isFinished)
        {
            timerText.color = Color.red;
            button.interactable = true;
        }
        else
        {
            timerText.color = Color.black;
            button.interactable = false;
        }
    }

    private void SetTimerText(float currentTime)
    {
        //if user wants a format with their time, go for it. else, do the default
        timerText.text = hasFormat ? currentTime.ToString(timerFormats[format]) : currentTime.ToString();
    }

    private void UpdatePomoMode(PomodoroState state)
    {
        if (state == PomodoroState.None)
        {
            buttonText.text = "Start!";
            button.image.color = Color.black;
        }
        else if (state == PomodoroState.Break)
        {
            buttonText.text = "Break";
            button.image.color = Color.cyan;
        }
        else
        {
            buttonText.text = "Pomo";
            button.image.color = Color.red;
        }
    }

    public void OnEnable()
    {
        EventHub.Instance.OnPomodoroStateSwitch += UpdatePomoMode;
    }

    public void OnDisable()
    {
        EventHub.Instance.OnPomodoroStateSwitch -= UpdatePomoMode;
    }
}
public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}
