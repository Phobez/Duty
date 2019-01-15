using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Made by : Abia Putrama Herlianto
 *           3 January 2019
 * SEE ALSO: Unlocker.cs
 */ 

// a component to create a lock on the object that does not allow the player to pass through
public class Locking : MonoBehaviour {

    private Collider2D coll;


    public bool locked = true;

	// Use this for initialization
	void Start () {
        coll = GetComponent<Collider2D>();

        coll.isTrigger = !locked;
	}

    // a method to unlock object
    public void Unlock()
    {
        locked = false;
        coll.isTrigger = !locked;
    }
}
