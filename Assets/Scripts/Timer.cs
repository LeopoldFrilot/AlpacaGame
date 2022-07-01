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

    // Start is called before the first frame update
    void Start()
    {
        
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
        timerText.text = currentTime.ToString();
    }








}
