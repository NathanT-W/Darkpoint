﻿using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public  Slider backgroundSlider, soundEffectsSlider;
    private float backgroundfloat, soundEffectsfloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio; 

        
    
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundfloat = .125f;
            soundEffectsfloat = .75f;
            backgroundSlider.value = backgroundfloat;
            soundEffectsSlider.value = soundEffectsfloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundfloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
           backgroundfloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundfloat;
            soundEffectsfloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsfloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
            
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
            GUIUtility.ExitGUI();
        }
    }
  
}
