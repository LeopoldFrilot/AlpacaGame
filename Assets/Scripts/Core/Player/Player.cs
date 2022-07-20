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
    }
    #endregion
    
    public CropSO selectedCropSeed;
    
    private GameplayManager gameplayManager;

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

    public GameplayManager GetGameplayManager()
    {
        if (gameplayManager == null)
        {
            gameplayManager = FindObjectOfType<GameplayManager>();
        }

        return gameplayManager;
    }

    private void OnEnable()
    {
        EventHub.OnClickDown += HandleClickDown;
    }
    
    private void OnDisable()
    {
        EventHub.OnClickDown -= HandleClickDown;
    }
}
