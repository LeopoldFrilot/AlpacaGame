using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PomodoroState
{
    None,
    Pomodoro,
    Break
}

public class GameplayManager : MonoBehaviour
{
    public FarmScene farm;
    public VillageScene village;
    public FairScene fair;

    private IGameScene currentScene;

    private void Start()
    {
        SwitchToFarm();
    }

    public void SwitchToFarm()
    {
        SetCurrentScene(farm);
    }
    
    public void SwitchToVillage()
    {
        SetCurrentScene(village);
    }

    public void SwitchToFair()
    {
        SetCurrentScene(fair);
    }

    public void SwitchToNone()
    {
        SetCurrentScene(null);
    }
    
    private void SetCurrentScene(IGameScene newScene)
    {
        if (currentScene != newScene)
        {
            currentScene = newScene;
            Debug.Log("New Scene: " + newScene);
            if (currentScene != null)
            {
                currentScene.Initialize();
            }
        }
    }

    public IGameScene GetCurrentScene()
    {
        return currentScene;
    }
}
