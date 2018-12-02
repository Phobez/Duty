using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private Vector2 currDir;

    private bool isFacingRight;

    private int interactableLayer;

	// Use this for initialization
	void Start () {
        interactableLayer = LayerMask.GetMask("Interactable");
	}
	
	// Update is called once per frame
	void Update () {
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_FacingRight;

        if (isFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 1.0f, interactableLayer);

        if (hit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.SendMessage("Interact", gameObject);
                // For TRANSPORTER/STAIRS
                // gameObject.transform.position = hit.transform.gameObject.GetComponent<Transporter>().GetTargetCoords();
            }
        }
    }
}
