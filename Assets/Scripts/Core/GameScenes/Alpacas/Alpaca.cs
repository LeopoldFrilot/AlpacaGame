using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alpaca : MonoBehaviour
{
    public AlpacaStatsSO alpacaStat;
    public GameObject petParticles;
    public GeneralAlpacaSO generalAlpacaData;

    private AudioSource alpacaWalkLoop;
    
    private void Start()
    {
        alpacaWalkLoop = AudioHub.Instance.SetupLoopingClip(generalAlpacaData.walkSound, generalAlpacaData.walkSoundVolume);
    }

    private void PetAlpaca(Alpaca alpaca)
    {
        if (alpaca == this)
        {
            if (petParticles != null)
            {
                Instantiate(petParticles, transform);
            }
            AudioHub.Instance.PlayClip(generalAlpacaData.alpacaHeartsSound, generalAlpacaData.alpacaHeartsSoundVolume);
        }
    }
    private void OnEnable()
    {
        EventHub.OnAlpacaPet += PetAlpaca;
    }

    private void OnDisable()
    {
        EventHub.OnAlpacaPet -= PetAlpaca;
    }
}
