using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<summary>
/// This class manages the controls for the pomotimer
///</summary>
public class Timer : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime; 
    }










}
