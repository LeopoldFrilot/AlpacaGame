using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IGameScene currentScene;

    public void SetCurrentScene(IGameScene newScene)
    {
        currentScene = newScene;
        currentScene.Initialize();
    }
}
