using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    public GameSO gameData;
    void Start()
    {
        AudioHub.Instance.SetMusic(gameData.splashScreenMusic, gameData.splashScreenMusicVolume);
    }
}
