using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlpacaDataUI : MonoBehaviour
{
    public GameObject AlpacaDataObj;

    public void ToggleAlpacaData()
    {
        AlpacaDataObj.SetActive(!AlpacaDataObj.activeSelf);
    }
}
