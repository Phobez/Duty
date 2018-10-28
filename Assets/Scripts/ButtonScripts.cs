using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public GameObject tutorialPanel;

    public void Play()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TryAgain()
    {
        RespawnData.HasRestarted = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        gameObject.GetComponent<GameManager>().Unpause();
    }

    public void HowToPlay()
    {
        tutorialPanel.SetActive(true);
    }

    public void Back()
    {
        tutorialPanel.SetActive(false);
    }
}
