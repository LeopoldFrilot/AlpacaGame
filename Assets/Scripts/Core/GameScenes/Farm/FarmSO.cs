using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmData", menuName = "ScriptableObjects/FarmData", order = 1)]
public class FarmSO : ScriptableObject
{
    [Header("Farming")]
    public AudioClip wateringSound;
    [Range(0,1)] public float wateringSoundVolume = 1;
    public AudioClip plantingSound;
    [Range(0,1)] public float plantingSoundVolume = 1;
    public AudioClip harvestingSound;
    [Range(0,1)] public float harvestingSoundVolume = 1;
    public AudioClip pickingWeedsSound;
    [Range(0,1)] public float pickingWeedsSoundVolume = 1;
    public AudioClip hoeingDirtSound;
    [Range(0,1)] public float hoeingDirtSoundVolume = 1;
    
    [Header("Ambience")]
    public AudioClip ambientSound;
    [Range(0,1)] public float ambientSoundVolume = 1;
}
