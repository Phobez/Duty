﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public enum GameState : byte { PLAYING, VICTORY, DEFEAT, PAUSED }

    private static GameManager instance;

    private GameState currGameState;

    private GameManager()
    {
        CurrGameState = GameState.PLAYING;
    }

    // a method to handle victory
    public void Victory(bool hasWon)
    {
        if (hasWon)
        {
            CurrGameState = GameState.VICTORY;
            Time.timeScale = 0.0f;
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to handle defeat
    public void Defeat(bool defeated)
    {
        if (defeated)
        {
            CurrGameState = GameState.DEFEAT;
            Time.timeScale = 0.0f;
            Debug.Log("Defeat");
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to handle pausing
    public void Pause(bool paused)
    {
        if (paused)
        {
            CurrGameState = GameState.PAUSED;
            Time.timeScale = 0.0f;
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to reset game state
    public void Playing(bool playing)
    {
        if (playing)
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    /////// PROPERTIES ///////
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public GameState CurrGameState
    {
        get
        {
            return currGameState;
        }
        set
        {
            this.currGameState = value;
        }
    }
}
