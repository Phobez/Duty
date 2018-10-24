using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GameState : byte { PLAYING, VICTORY, DEFEAT, PAUSE }

    public GameObject gameOverPanel;
    public GameObject player;

    private byte currState;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        currState = (byte)GameState.PLAYING;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currState)
        {
            case (byte)GameState.DEFEAT:
                Defeat();
                break;
        }
	}

    public void Defeat()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void SetCurrState(byte currState)
    {
        this.currState = currState;
    }


}
