using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GameState : byte { PLAYING, VICTORY, DEFEAT }

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject victoryPanel;
    public GameObject player;

    private byte currState;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        currState = (byte)GameState.PLAYING;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

		switch (currState)
        {
            case (byte)GameState.DEFEAT:
                Defeat();
                break;
            case (byte)GameState.VICTORY:
                Victory();
                break;
        }
	}

    public void Defeat()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1.0f;
    }

    public void SetCurrState(byte currState)
    {
        this.currState = currState;
    }


}
