using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Space]
    [Header("UI")]
    [SerializeField] private Canvas settingPanel;
    private CanvasGroup setttingGroup;
    [SerializeField] private Canvas creditsPanel;
    private CanvasGroup creditGroup;

    private void Awake()
    {
        settingPanel.enabled = false;
        creditsPanel.enabled = false;

        //creditGroup = creditsPanel.gameObject.GetComponent<CanvasGroup>();
        //setttingGroup = setttingGroup.gameObject.GetComponent<CanvasGroup>();
    }

    public void OpenCloseSettings()
    {
        creditsPanel.enabled = false;
        if(settingPanel.isActiveAndEnabled)
        {
            settingPanel.enabled = false;
        }
        else
        {
            settingPanel.enabled = true;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game Level Design",LoadSceneMode.Single);
        Debug.Log("Game Start");
    }

    public void OpenCloseCredits()
    {
        settingPanel.enabled = false;
        if(creditsPanel.isActiveAndEnabled)
        {
            creditsPanel.enabled = false;
        }
        else
        {
            creditsPanel.enabled = true;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quite Game");
        Application.Quit();
    }

}
