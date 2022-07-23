using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerSO : ScriptableObject
{
    public AudioClip walkSound;
    [Range(0,1)] public float walkSoundVolume = 1;
}
