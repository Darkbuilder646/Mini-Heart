using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] private Canvas settingsPanel, pausePanel;

    private void Awake() 
    {
        settingsPanel.enabled = false;    
        pausePanel.enabled = false;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("pause");
            if(isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        settingsPanel.enabled = false;
        pausePanel.enabled = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pausePanel.enabled = true;
        isPaused = true;
        Time.timeScale = 0;
    }

    public void OpenCloseSettings()
    {
        if(settingsPanel.isActiveAndEnabled)
        {
            settingsPanel.enabled = false;
        }
        else
        {
            settingsPanel.enabled = true;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu",LoadSceneMode.Single);
    }
}
