using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderMusic;
    public Slider sliderSounds;

    private void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sliderSounds.value = PlayerPrefs.GetFloat("SoundsVolume", 1f);
    }

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

    }

    public void SetLevelSounds(float sliderValue)
    {
        mixer.SetFloat("SoundsVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundsVolume", sliderValue);
    }
}
