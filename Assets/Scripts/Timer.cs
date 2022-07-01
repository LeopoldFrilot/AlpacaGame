using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<summary>
/// This class manages the controls for the pomotimer
///</summary>
public class TimerController : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("FormatSettings")]
    public bool hasFormat;
    public TimerFormats format;
    //timerFormats is an object that controls the format once its selected
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundrethsDecimal, "0.00");

    }

    // Update is called once per frame
    void Update()
    {
        //if timer is counting down, decrease timer. else, increase timer
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime; 
        
        //if there is a limit, check if the time has gone beyond the limit STOP
        if(hasLimit && ((countDown && currentTime <= timerLimit)) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false; //causes the component to stop running
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        //if user wants a format with their time, go for it. else, do the default
        timerText.text = hasFormat ? currentTime.ToString(timerFormats[format]) : currentTime.ToString();
    }


}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}
