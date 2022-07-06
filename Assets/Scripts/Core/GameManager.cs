using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PomodoroState
{
    None,
    Pomodoro,
    Break
}

public class GameManager : MonoBehaviour
{
    private IGameScene currentScene;

    public void SetCurrentScene(IGameScene newScene)
    {
        currentScene = newScene;
        currentScene.Initialize();
    }
}
