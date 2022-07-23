using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public GameObject PlayerDataObj;

    public void TogglePlayerData()
    {
        PlayerDataObj.SetActive(!PlayerDataObj.activeSelf);
    }
}
