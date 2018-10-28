using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visibility : MonoBehaviour {

    public Sprite visible;
    public Sprite invisible;

    private Hide player;

    private Image img;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hide>();

        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetIsHiding())
        {
            img.sprite = invisible;
        }
        else
        {
            img.sprite = visible;
        }
	}
}
