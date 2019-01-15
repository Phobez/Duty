using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaptersManager : MonoBehaviour {

    public Button[] chapterButtons;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 4; i++)
        {
            if (Game.current.levels[i])
            {
                chapterButtons[i].interactable = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
