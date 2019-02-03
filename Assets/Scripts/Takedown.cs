using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedown : MonoBehaviour {

    public AudioClip stabSound;

    private AudioSource audioSource;

    private Animator anim;

    private Vector2 currDir;

    public float takedownCooldown;
    private float takedownTimer;

    private int enemyLayer;

    private bool isFacingRight;
    private bool isHiding;
    private bool hasTakendown;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 1.0f, enemyLayer);

            if(hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (CanTakedown(hit) && !isHiding && !hasTakendown)
                {
                    audioSource.PlayOneShot(stabSound);
                    anim.SetBool("Takedown", true);
                    hit.collider.SendMessage("Die");
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
        if (hit.transform.gameObject.GetComponent<EnemyAI>().CurrState == EnemyAI.EnemyState.ASLEEP)
        {
            return true;
        }

        bool isTargetFacingRight = hit.transform.gameObject.GetComponent<EnemyAI>().isFacingRight;
        
        if (isFacingRight == isTargetFacingRight)
        {
            if (hit.transform.gameObject.GetComponent<EnemyAI>().isJuggernaut)
            {
                return false;
            }
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
