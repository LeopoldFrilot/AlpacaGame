using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GeneralAlpacaData", menuName = "ScriptableObjects/GeneralAlpacaData", order = 1)]
public class GeneralAlpacaSO : ScriptableObject
{
    public AudioClip walkSound;
    [Range(0,1)] public float walkSoundVolume = .5f;
    public AudioClip alpacaHeartsSound;
    [Range(0,1)] public float alpacaHeartsSoundVolume = .5f;
    public AudioClip shearingAlpacaSound;
    [Range(0,1)] public float shearingAlpacaSoundVolume = .5f;
}
