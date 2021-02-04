using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;


    public GameObject pauseMenuUi;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();

            }
        }
    }

    public void Resume ()
    {
        pauseMenuUi.SetActive(false);
        GameIsPaused = false;
    }

    void Pause ()

    {
        pauseMenuUi.SetActive(true);
        GameIsPaused = true;
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
