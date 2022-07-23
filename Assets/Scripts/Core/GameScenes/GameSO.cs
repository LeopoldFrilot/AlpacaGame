using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameSO : ScriptableObject
{
    [Header("UI")]
    public AudioClip splashScreenMusic;
    [Range(0,1)] public float splashScreenMusicVolume = 1;
    public AudioClip clickMenuSound;
    [Range(0,1)] public float clickMenuSoundVolume = 1;
    
    [Header("Pomodoro")]
    public AudioClip pomodoroStartSound;
    [Range(0,1)] public float pomodoroStartSoundVolume = 1;
    public AudioClip pomodoroEndSound;
    [Range(0,1)] public float pomodoroEndSoundVolume = 1;
    public AudioClip pomodoroFinishMusic;
    [Range(0,1)] public float pomodoroFinishMusicVolume = 1;
    public AudioClip breakStartSound;
    [Range(0,1)] public float breakStartSoundVolume = 1;
    public AudioClip breakEndSound;
    [Range(0,1)] public float breakEndSoundVolume = 1;
}
