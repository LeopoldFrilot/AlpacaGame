using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroUI : MonoBehaviour
{
    public GameObject pomodoroMakerObj;

    public void TogglePomodoroMaker()
    {
        pomodoroMakerObj.SetActive(!pomodoroMakerObj.activeSelf);
    }
}
