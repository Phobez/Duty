using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GameState : byte { PLAYING, VICTORY, DEFEAT, PAUSE }

    byte currState;

	// Use this for initialization
	void Start () {
        currState = (byte)GameState.PLAYING;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Defeat()
    {
        // Debug.Log("Defeat!");
    }


}
