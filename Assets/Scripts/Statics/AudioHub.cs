using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioHub : MonoBehaviour
{
    public AudioSource musicPlayer;
    private float iniMusicVolume;
    private List<AudioSource> loopingClips = new List<AudioSource>();
    private List<float> initialVolumes = new List<float>();
    private AudioSource audioSource;

    #region Singleton
    private static AudioHub _instance;
    public static AudioHub Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("AudioHub");
                gO.AddComponent<AudioHub>().Awake();
            }
            return _instance;
        }
    }


    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(_instance.gameObject);
        }
    }
    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (musicPlayer)
        {
            iniMusicVolume = musicPlayer.volume;
            musicPlayer.volume = ScaleMusicVolume(iniMusicVolume);
        }
    }

    public void PlayClip(AudioClip clip, float volumeScale)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, ScaleSFXVolume(volumeScale));
        }
    }

    public AudioSource SetupLoopingClip(AudioClip clip, float volumeScale)
    {
        if (clip != null)
        {
            GameObject gO = new GameObject();
            gO.transform.parent = transform;

            AudioSource newAudioSource = gO.AddComponent<AudioSource>();
            newAudioSource.clip = clip;
            newAudioSource.volume = ScaleSFXVolume(volumeScale);
            newAudioSource.loop = true;
            newAudioSource.playOnAwake = false;

            loopingClips.Add(newAudioSource);
            initialVolumes.Add(volumeScale);

            return newAudioSource;
        }

        return null;
    }

    public void PlayLoopingCLip(AudioSource source)
    {
        if (source != null && !source.isPlaying)
        {
            source.Play();
        }
    }

    public void SetMusic(AudioClip clip, float volumeScale)
    {
        if (musicPlayer != null && clip != null)
        {
            musicPlayer.clip = clip;
            musicPlayer.volume = ScaleMusicVolume(volumeScale);
        }
    }

    private float ScaleSFXVolume(float rawVal)
    {
        //float val = StaticSettings.sfxVolumeScalar;
        //if (StaticSettings.sfxVolumeMuted) val *= 0f;
        //return rawVal * val;
        return rawVal;
    }

    private float ScaleMusicVolume(float rawVal)
    {
        //float val = StaticSettings.musicVolumeScalar;
        //if (StaticSettings.musicVolumeMuted) val *= 0f;
        //return rawVal * val;
        return rawVal;
    }

    private void UpdateLoopingSFX()
    {
        for (int i = 0; i < loopingClips.Count; i++)
        {
            loopingClips[i].volume = ScaleSFXVolume(initialVolumes[i]);
        }
    }

    private void UpdateMusic()
    {
        if (musicPlayer)
        {
            musicPlayer.volume = ScaleMusicVolume(iniMusicVolume);
        }
    }

    private void OnEnable()
    {
        EventHub.OnSFXVolumeChanged += UpdateLoopingSFX;
        EventHub.OnMusicVolumeChanged += UpdateMusic;
    }

    private void OnDisable()
    {
        EventHub.OnSFXVolumeChanged -= UpdateLoopingSFX;
        EventHub.OnMusicVolumeChanged -= UpdateMusic;
    }
}