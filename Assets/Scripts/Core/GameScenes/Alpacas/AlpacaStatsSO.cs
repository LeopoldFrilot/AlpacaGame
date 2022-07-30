using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "AlpacaStats", menuName = "ScriptableObjects/AlpacaStats", order = 7)]
public class AlpacaStatsSO : ScriptableObject
{

    public enum AlpacaStat
    {
        Description,
        Love,
        Energy,
        Amicability,
        CoatQuality,
        Strength,
        Speed,
        Toughness,
        Smarts,
        Cuteness,
        Drip,
        Uncanny
    }

    [FormerlySerializedAs("loveStat")] public int loveStat;
    


}
