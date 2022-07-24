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
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Dropdown dropdownPomo;
    [SerializeField] private TMP_Dropdown dropdownBreak;

    [Header("FormatSettings")]
    [SerializeField] private bool hasFormat;
    [SerializeField] private TimerFormats format;
    [SerializeField] private Color defaultTimerTextColor = Color.white;
    [SerializeField] private Color finishedTimerTextColor = Color.red;
    
    //timerFormats is an object that controls the format once its selected
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();

    private float storedPomoTime;
    private float storedBreakTime;
    
    // Start is called before the first frame update
    private void Start()
    {
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundrethsDecimal, "0.00");  
        dropdownPomo.onValueChanged.AddListener(delegate { DropdownPomodoroValueChanged(dropdownPomo);});
        dropdownBreak.onValueChanged.AddListener(delegate { DropdownBreakValueChanged(dropdownBreak);});
        DropdownPomodoroValueChanged(dropdownPomo);
        DropdownBreakValueChanged(dropdownBreak);
    }

    public void ChangeTime(float time, bool isFinished)
    {
        SetTimerText(time);
        if (isFinished)
        {
            timerText.color = finishedTimerTextColor;
            button.interactable = true;
        }
        else
        {
            timerText.color = defaultTimerTextColor;
            button.interactable = false;
        }
    }

    private void SetTimerText(float currentTime)
    {
        //if user wants a format with their time, go for it. else, do the default
        int minutes = (int)currentTime / 60;
        int seconds = (int)(currentTime - minutes * 60);
        timerText.text = minutes + ":" + (seconds < 10 ? "0" : "") + (hasFormat ? seconds.ToString(timerFormats[format]) : seconds.ToString());
    }

    private void UpdatePomoMode(PomodoroState state)
    {
        if (state == PomodoroState.None)
        {
            buttonText.text = "Start!";
            button.image.color = Color.red;
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
    
    private void DropdownPomodoroValueChanged(TMP_Dropdown change)
    {
        storedPomoTime = Helper.MinutesToSeconds(change.value * 5f + 25f);
    }
    
    private void DropdownBreakValueChanged(TMP_Dropdown change)
    {
        storedBreakTime = Helper.MinutesToSeconds(change.value * 5f + 5f);
    }

    public Vector2 GetPomodoroTimes()
    {
        return new Vector2(storedPomoTime, storedBreakTime);
    }

    public void OnEnable()
    {
        EventHub.OnPomodoroStateSwitch += UpdatePomoMode;
    }

    public void OnDisable()
    {
        EventHub.OnPomodoroStateSwitch -= UpdatePomoMode;
    }
}
public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}
