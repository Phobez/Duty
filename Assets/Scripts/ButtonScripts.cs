using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public GameObject tutorialPanel;

    public void Play()
    {
        GameManager.Instance.Playing(true);
        SceneManager.LoadScene("DemoLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        GameManager.Instance.Playing(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TryAgain()
    {
        RespawnData.HasRestarted = true;
        Debug.Log("Try Again: " + RespawnData.HasRestarted);
        GameManager.Instance.Playing(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        GameManager.Instance.Playing(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        GameManager.Instance.Pause(false);
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
