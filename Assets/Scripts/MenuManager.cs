using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject victoryPanel;

    public Text kills;
    public Text time;

    public LevelStats levelStats;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Pause(true);
        }

        switch (GameManager.Instance.CurrGameState)
        {
            case GameManager.GameState.VICTORY:
                kills.text = levelStats.kills.ToString();
                time.text = levelStats.levelTime.ToString();

                gameOverPanel.SetActive(false);
                pausePanel.SetActive(false);
                victoryPanel.SetActive(true);
                break;
            case GameManager.GameState.DEFEAT:
                gameOverPanel.SetActive(true);
                pausePanel.SetActive(false);
                victoryPanel.SetActive(false);
                break;
            case GameManager.GameState.PAUSED:
                gameOverPanel.SetActive(false);
                pausePanel.SetActive(true);
                victoryPanel.SetActive(false);
                break;
            case GameManager.GameState.PLAYING:
                gameOverPanel.SetActive(false);
                pausePanel.SetActive(false);
                victoryPanel.SetActive(false);
                break;
        }
    }
}
