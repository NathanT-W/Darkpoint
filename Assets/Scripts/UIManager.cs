using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{

    public GameObject mainMenuUI, settingsUI, levelSelectUI;
    AudioMixer mixer;
        
    public void SetLevel (float slidervalue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(slidervalue) * 20);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void startButton()
    {
        levelSelectUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void settingsButton()
    {
        settingsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void backButton(GameObject currentUI)
    {
        currentUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void loadLevelByIndex(int level)
    {
        SceneManager.LoadScene(level);
    }

}