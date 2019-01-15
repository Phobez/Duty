using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    // public GameObject tutorialPanel;

    public void Play()
    {
        GameManager.Instance.Playing(true);
        RespawnData.Reset();
        SceneManager.LoadScene("Chapter1");
    }

    public void Chapters()
    {
        SceneManager.LoadScene("Chapters");
    }

    public void SelectChapter(string chapterName)
    {
        SceneManager.LoadScene(chapterName);
    }

    public void ToggleTakedownMode()
    {
        switch (PlayerPrefs.GetInt("Takedown"))
        {
            case 0:
                PlayerPrefs.SetInt("Takedown", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("Takedown", 0);
                break;
        }

        Debug.Log(PlayerPrefs.GetInt("Takedown"));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        GameManager.Instance.Playing(true);
        RespawnData.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TryAgain()
    {
        RespawnData.HasRestarted = true;
        // Debug.Log("Try Again: " + RespawnData.HasRestarted);
        GameManager.Instance.Playing(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        GameManager.Instance.Playing(true);
        RespawnData.Reset();
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        GameManager.Instance.Pause(false);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
    public void HowToPlay()
    {
        tutorialPanel.SetActive(true);
    }

    public void Back()
    {
        tutorialPanel.SetActive(false);
    }
    */
}
