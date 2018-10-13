using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private RaycastHit2D hit;

    private int playerLayer;

    // Use this for initialization
    void Start () {
        playerLayer = LayerMask.GetMask("Player");
	}
	
	// Update is called once per frame
	void Update () {
        hit = Physics2D.Raycast(transform.position, Vector2.left, 10.0f, playerLayer);

        if (hit)
        {

            Debug.Log("hit");
            Hide hide = hit.transform.gameObject.GetComponent<Hide>();

            if (hide.GetIsHiding())
            {
                // Debug.Log("Hit but cannot see");
            }
            else
            {
                // Debug.Log("Hit and can see");
            }
        }
	}

}