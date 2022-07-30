using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public GameObject PlayerDataObj;
    public TMP_Dropdown seedSelector;
    public TextMeshProUGUI numberOfSeedsText;
    public TextMeshProUGUI solesText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI harvestedWheatText;
    public TextMeshProUGUI harvestedTomatoesText;

    [SerializeField] CropSO[] crops;

    private void Start()
    {
        seedSelector.onValueChanged.AddListener(delegate { SelectSeed(seedSelector.value); });
        SelectSeed(0);
    }

    public void TogglePlayerData()
    {
        PlayerDataObj.SetActive(!PlayerDataObj.activeSelf);
    }

    private void SelectSeed(int index)
    {
        if (index < crops.Length)
        {
            EventHub.TriggerCropSeedSelected(crops[index]);
            UpdateSeedCount(crops[index]);
        }
    }

    private void UpdateSeedCount(CropSO crop)
    {
        for (int i = 0; i < crops.Length; i++)
        {
            if (seedSelector.value == i && crops[i] == crop)
            {
                numberOfSeedsText.text = Player.Instance.GetSeedCount(crops[i].cropType).ToString();
            }
        }
    }

    private void UpdateCoins(int newValue)
    {
        coinsText.text = newValue.ToString();
    }

    private void UpdateSoles(int newValue)
    {
        solesText.text = newValue.ToString();
    }

    private void OnEnable()
    {
        EventHub.OnCropSeedCountChanged += UpdateSeedCount;
        EventHub.OnCoinsCountChanged += UpdateCoins;
        EventHub.OnSolesCountChanged += UpdateSoles;
    }
    private void OnDisable()
    {
        EventHub.OnCropSeedCountChanged -= UpdateSeedCount;
        EventHub.OnCoinsCountChanged -= UpdateCoins;
        EventHub.OnSolesCountChanged -= UpdateSoles;
    }
}
