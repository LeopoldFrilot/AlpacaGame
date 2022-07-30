using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameSO : ScriptableObject
{
    [Header("UI")]
    public AudioClip splashScreenMusic;
    [Range(0,1)] public float splashScreenMusicVolume = .5f;
    public AudioClip clickMenuSound;
    [Range(0,1)] public float clickMenuSoundVolume = .5f;
    
    [Header("Pomodoro")]
    public AudioClip pomodoroStartSound;
    [Range(0,1)] public float pomodoroStartSoundVolume = .5f;
    public AudioClip pomodoroEndSound;
    [Range(0,1)] public float pomodoroEndSoundVolume = .5f;
    public AudioClip pomodoroFinishMusic;
    [Range(0,1)] public float pomodoroFinishMusicVolume = .5f;
    public AudioClip breakStartSound;
    [Range(0,1)] public float breakStartSoundVolume = .5f;
    public AudioClip breakEndSound;
    [Range(0,1)] public float breakEndSoundVolume = .5f;

    [Header("Minigame")]
    public AudioClip miningRhythmSound;
    [Range(0, 1)] public float miningRhythmSoundVolume = .5f;
    public AudioClip fishingSound;
    [Range(0, 1)] public float fishingSoundVolume = .5f;
}
