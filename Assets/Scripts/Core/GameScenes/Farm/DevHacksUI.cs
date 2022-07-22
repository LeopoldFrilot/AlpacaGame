using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevHacksUI : MonoBehaviour
{
    public GameObject devHacksObj;

    public void ToggleDevHacks()
    {
        devHacksObj.SetActive(!devHacksObj.activeSelf);
    }

    public void FinishTimer()
    {
        EventHub.TriggerTimerForceEnd();
    }
}
