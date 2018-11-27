using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

    private SpriteRenderer sprRend;

    private Vector2 currDir;
    private Vector3 hidePos;

    private bool isHiding;
    private bool isFacingRight;
    private bool isHidingBehind;
    private bool isCloaked;

    private int hideableLayer;
    
	// Use this for initialization
	void Start () {
        sprRend = GetComponent<SpriteRenderer>();

        isHiding = false;

        hideableLayer = LayerMask.GetMask("Hideable");
	}
	
	// Update is called once per frame
	void Update () {
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().GetM_FacingRight();

        if (isFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 0.1f, hideableLayer);

        if (IsCloaked)
        {
            IsHiding = true;
        }

        if (hit && !IsCloaked)
        {
            if (hit.transform.gameObject.tag == "Hideable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isHiding)
                    {
                        sprRend.enabled = true;
                        isHiding = false;
                        isHidingBehind = false;
                    }
                    else
                    {
                        sprRend.enabled = false;
                        isHiding = true;
                        isHidingBehind = true;
                        hidePos = transform.position;
                    }
                }
            }
            else if (hit.transform.gameObject.tag == "HideBehind")
            {
                isHiding = true;
            }
        }
        else if (!IsCloaked)
        {
            isHiding = false;
        }

        if (isHidingBehind)
        {
            transform.position = hidePos;
        }

	}

    /////// PROPERTIES ///////
    public bool IsHiding
    {
        get
        {
            return isHiding;
        }
        set
        {
            isHiding = value;
        }
    }

    public bool IsCloaked
    {
        get
        {
            return isCloaked;
        }
        set
        {
            isCloaked = value;
        }
    }
}
