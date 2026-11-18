using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol01", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol01", 1f);

        AudioManager.instance?.SetMusicVolume(musicSlider.value);
        AudioManager.instance?.SetSFXVolume(sfxSlider.value);

        musicSlider.onValueChanged.AddListener(v => {
            AudioManager.instance?.SetMusicVolume(v);
            PlayerPrefs.SetFloat("MusicVol01", v);
        });
        sfxSlider.onValueChanged.AddListener(v => {
            AudioManager.instance?.SetSFXVolume(v);
            PlayerPrefs.SetFloat("SFXVol01", v);
        });
    }
}

