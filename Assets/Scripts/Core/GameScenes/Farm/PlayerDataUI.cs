using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public GameObject PlayerDataObj;
    public TextMeshProUGUI harvestedText;
    private int cropsHarvested = 0;

    public void TogglePlayerData()
    {
        PlayerDataObj.SetActive(!PlayerDataObj.activeSelf);
    }

    private void UpdateCropsHarvested(CropRoot crop)
    {
        cropsHarvested++;
        if (harvestedText != null)
        {
            harvestedText.text = "Harvested: " + cropsHarvested;
        }
    }

    private void OnEnable()
    {
        EventHub.OnCropHarvested += UpdateCropsHarvested;
    }
    
    private void OnDisable()
    {
        EventHub.OnCropHarvested -= UpdateCropsHarvested;
    }
}
