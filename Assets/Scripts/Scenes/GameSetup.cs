using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

    private void Awake()
    {
        PlayerPrefs.SetInt("Takedown", 0);
    }
}
