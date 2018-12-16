using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedownable : MonoBehaviour {

    public GameObject e;

    private Collider2D[] player;

	// Use this for initialization
	void Start () {
        e.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        player = Physics2D.OverlapBoxAll(transform.position, new Vector2(3, 0), 0, LayerMask.GetMask("Player"));

        if (player.Length > 0)
        {
            e.SetActive(true);
        }
        else
        {
            e.SetActive(false);
        }
	}
}
