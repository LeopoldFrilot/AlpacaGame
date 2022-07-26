using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmData", menuName = "ScriptableObjects/FarmData", order = 1)]
public class FarmSO : ScriptableObject
{
    [Header("Farming")]
    public AudioClip wateringSound;
    [Range(0,1)] public float wateringSoundVolume = .5f;
    public AudioClip plantingSound;
    [Range(0,1)] public float plantingSoundVolume = .5f;
    public AudioClip harvestingSound;
    [Range(0,1)] public float harvestingSoundVolume = .5f;
    public AudioClip pickingWeedsSound;
    [Range(0,1)] public float pickingWeedsSoundVolume = .5f;
    public AudioClip hoeingDirtSound;
    [Range(0,1)] public float hoeingDirtSoundVolume = .5f;
    
    [Header("Ambience")]
    public AudioClip ambientSound;
    [Range(0,1)] public float ambientSoundVolume = .5f;
}
