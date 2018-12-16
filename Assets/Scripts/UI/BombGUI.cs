﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombGUI : MonoBehaviour {

    public Sprite active;
    public Sprite inactive;

    private ToolSelect player;

    private Image img;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ToolSelect>();

        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.bombs > 0)
        {
            img.sprite = active;
        }
        else
        {
            img.sprite = inactive;
        }
	}
}
