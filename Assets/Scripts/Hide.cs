using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

    private SpriteRenderer sprRend;

    private bool isHiding;

    private int hideableLayer;
    
	// Use this for initialization
	void Start () {
        sprRend = GetComponent<SpriteRenderer>();

        isHiding = false;

        hideableLayer = LayerMask.GetMask("Hideable");
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1.0f, hideableLayer);

            if (hit && !isHiding)
            {
                sprRend.enabled = false;
                isHiding = true;
            }
            else if (hit && isHiding)
            {
                sprRend.enabled = true;
                isHiding = false;
            }
        }

	}

    public bool GetIsHiding()
    {
        return isHiding;
    }
}
