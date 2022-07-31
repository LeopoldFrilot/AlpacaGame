using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alpaca : MonoBehaviour
{
    public AlpacaPet alpacaPet;
    public AlpacaStatsSO alpacaStat;
    public GameObject petParticles;

    private void PetAlpaca(Alpaca alpaca)
    {
        if (alpaca == this)
        {
            
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
