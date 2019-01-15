using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockController : MonoBehaviour {

    private Locking locking;
    private SpriteRenderer sprRend;

    public Sprite closed;
    public Sprite open;

	// Use this for initialization
	void Start () {
        locking = GetComponent<Locking>();
        sprRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (locking.locked)
        {
            sprRend.sprite = closed;
        }
        else
        {
            sprRend.sprite = open;
        }
	}
}
