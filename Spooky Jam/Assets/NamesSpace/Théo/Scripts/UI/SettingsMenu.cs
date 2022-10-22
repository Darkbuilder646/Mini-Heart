using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Space]
    [Header("Sound")]
    [SerializeField] private AudioMixer mixer;

    [Space]
    [Header("Slider")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Space]
    [Header("Resolutions")]
    private bool isFullScreen = true;

    private void Awake()
    {
        InitSlider();
        
        Screen.fullScreen = isFullScreen;
    }

    private void InitSlider()
    {
        mixer.GetFloat("MasterVolume", out float masterValueForSlider);
        masterSlider.value = masterValueForSlider;

        mixer.GetFloat("MusicVolume", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        mixer.GetFloat("SFXVolume", out float sfxValueForSlider);
        sfxSlider.value = sfxValueForSlider;
    }

    public void SetMaster(float master)
    {
        mixer.SetFloat("MasterVolume", master);
    }
    public void SetMusic(float music)
    {
        mixer.SetFloat("MusicVolume", music);
    }
    public void SetSFX(float sfx)
    {
        mixer.SetFloat("SFXVolume", sfx);
    }

    public void SetFullScreen()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

}
