using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Toggle muteToggle;

    public static Action<AudioClip> PlaySFXRequested;

    bool isMute = false;
    string musicVolParam = "MusicVol";
    string sfxVolParam = "SFXVol";

    void Start()
    {
        SetVolumeSettings();
    }
    void OnEnable()
    {
        PlaySFXRequested += PlaySFX;
    }

    void OnDisable()
    {
        PlaySFXRequested -= PlaySFX;
    }

    void SetVolumeSettings()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVol);
        sfxSlider.onValueChanged.AddListener(SetSFXVol);

        float musicVolume = PlayerPrefs.GetFloat("MusicVolume",1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume",1f);
        bool mute = PlayerPrefs.GetInt("Mute",0)==1;

        SetMusicVol(musicVolume);
        SetSFXVol(sfxVolume);

        musicSlider.value=musicVolume;
        sfxSlider.value=sfxVolume;

        isMute=mute;
        muteToggle.SetIsOnWithoutNotify(isMute);
        AudioListener.volume = isMute ? 0f : 1f;
    }

    public void SetMusicVol(float volume)
    {
        SetVolume(musicVolParam,volume);
        PlayerPrefs.SetFloat("MusicVolume",volume);
        PlayerPrefs.Save();
    }
    
    public void SetSFXVol(float volume)
    {
        SetVolume(sfxVolParam,volume);
        PlayerPrefs.SetFloat("SFXVolume",volume);
        PlayerPrefs.Save();
    }

    void SetVolume(string param, float volume)
    {
        float dB= Mathf.Log10(Mathf.Max(volume,0.0001f))*20;
        audioMixer.SetFloat(param,dB);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }

    public void ToggleMute()
    {
        isMute=!isMute;
        AudioListener.volume = isMute ? 0f : 1f;
        PlayerPrefs.SetInt("Mute",isMute?1:0);
        PlayerPrefs.Save();
    }

}
