using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockController : MonoBehaviour {

    private Locking locking;
    private SpriteRenderer sprRend;
    private AudioSource audioSource;

    public Sprite closed;
    public Sprite open;

    public AudioClip openSound;

    private bool hasSounded;

	// Use this for initialization
	void Start () {
        locking = GetComponent<Locking>();
        sprRend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        hasSounded = false;
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
            if (!hasSounded)
            {
                hasSounded = true;
                audioSource.PlayOneShot(openSound);
            }
        }
	}
}
