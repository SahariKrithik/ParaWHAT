using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneSettings : MonoBehaviour
{
    public static MainSceneSettings instance; 

    public GameObject settingsPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void OpenMenuInMainScene()
    {
        settingsPanel.SetActive(true);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void CloseMenuInMainScene()
    {
        settingsPanel.SetActive(false);
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void ClosePausedPanel()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;

    }
    


}
