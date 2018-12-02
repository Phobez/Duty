using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedown : MonoBehaviour {

    private Vector2 currDir;

    public float takedownCooldown = 2.0f;
    private float takedownTimer;

    private int enemyLayer;

    private bool isFacingRight;
    private bool isHiding;
    private bool hasTakendown;

	// Use this for initialization
	void Start () {
        enemyLayer = LayerMask.GetMask("Enemy");

        takedownTimer = takedownCooldown;

        hasTakendown = false;
	}
	
	// Update is called once per frame
	void Update () {
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_FacingRight;
        isHiding = GetComponent<Hide>().IsHiding;

        if (isFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 0.5f, enemyLayer);

            if(hit)
            {
                if (CanTakedown(hit) && !isHiding && !hasTakendown)
                {
                    Debug.Log("TIMER START");
                    Destroy(hit.transform.gameObject);
                    hasTakendown = true;
                }
            }
        }

        if (hasTakendown && takedownTimer > 0)
        {
            takedownTimer -= Time.deltaTime;
        }
        else if (hasTakendown && takedownTimer <= 0)
        {
            Debug.Log("TIMER END");
            hasTakendown = false;
            takedownTimer = takedownCooldown;
        }
	}

    private bool CanTakedown(RaycastHit2D hit)
    {
        bool isTargetFacingRight = hit.transform.gameObject.GetComponent<EnemyAI>().isFacingRight;
        
        if (isFacingRight == isTargetFacingRight)
        {
            return true;
        }

        return false;
    }

    /////// PROPERTIES ///////
    public bool HasTakendown
    {
        get
        {
            return hasTakendown;
        }
    }
}
