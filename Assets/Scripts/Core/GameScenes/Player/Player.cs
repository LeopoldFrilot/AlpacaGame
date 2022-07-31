using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("Player");
                gO.AddComponent<Player>().Awake();
            }
            return _instance;
        }
    }


    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        NonSingletonAwake();
    }
    #endregion

    private PlayerStats playerStats;
    private PlayerSO playerData;
    private CropSO selectedCropSeed;
    private GameplayManager gameplayManager;
    private AudioSource walkingSoundLoop;

    private void NonSingletonAwake()
    {
        playerStats = new PlayerStats(500, 15, 10, 4);
    }

    private void Start()
    {
        EventHub.TriggerCoinsCountChanged(playerStats.coins);
        EventHub.TriggerSolesCountChanged(playerStats.soles);
        walkingSoundLoop = AudioHub.Instance.SetupLoopingClip(playerData.walkSound, playerData.walkSoundVolume);
    }

    private void HandleClickDown(Vector2 worldPos)
    {
        if (GetGameplayManager() != null)
        {
            var farm = gameplayManager.farm;
            if (gameplayManager.GetCurrentScene() == farm)
            {
                farm.HandleClick(worldPos);
            }
        }
    }

    public int GetSeedCount(CropSO.CropType cropType)
    {
        return playerStats.GetSeedCount(cropType);
    }

    public GameplayManager GetGameplayManager()
    {
        if (gameplayManager == null)
        {
            gameplayManager = FindObjectOfType<GameplayManager>();
        }

        return gameplayManager;
    }

    public void ChangeSeedCount(CropSO seed, int v)
    {
        playerStats.ChangeSeedCount(seed.cropType, v);
        EventHub.TriggerCropSeedCountChanged(seed);
    }

    public CropSO GetSelectedCropSeed()
    {
        return selectedCropSeed;
    }

    public void CoinChange(int delta)
    {
        playerStats.coins += delta;
        EventHub.TriggerCoinsCountChanged(playerStats.coins);
    }

    public void SolesChange(int delta)
    {
        playerStats.soles += delta;
        EventHub.TriggerSolesCountChanged(playerStats.soles);
    }

    private void UpdateCropseedSelection(CropSO cropSeed)
    {
        selectedCropSeed = cropSeed;
    }

    private void UpdateCropsHarvested(CropRoot crop)
    {
        playerStats.HarvestCrop(crop.GetCropType(), 1);
    }

    private void OnEnable()
    {
        EventHub.OnClickDown += HandleClickDown;
        EventHub.OnCropHarvested += UpdateCropsHarvested;
        EventHub.OnCropSeedSelected += UpdateCropseedSelection;
        EventHub.OnPomodoroEnded += SolesChange;
    }
    
    private void OnDisable()
    {
        EventHub.OnClickDown -= HandleClickDown;
        EventHub.OnCropHarvested -= UpdateCropsHarvested;
        EventHub.OnCropSeedSelected -= UpdateCropseedSelection;
        EventHub.OnPomodoroEnded -= SolesChange;
    }
}
