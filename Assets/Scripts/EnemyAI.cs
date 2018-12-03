using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyAI : MonoBehaviour {

    public enum EnemyState : byte { PATROL, CHASE, GUARD, ASLEEP };
    /// <summary>
    /// MONODIR -> e.g. patrols left, returns to origin, patrols right, returns to origin, repeat
    /// BIDIR -> e.g. patrols left, returns to origin, repeat
    /// </summary>
    public enum PatrolType : byte { MONODIR = 1, BIDIR };

    public EnemyState initialState; // default value is PATROL
    private EnemyState currState;

    public PatrolType patrolType; // default value is BIDIR

    public LevelStats levelStats;

    private Animator anim;

    private SpriteRenderer sprRend;

    private Vector3 originPos;

    private Vector2 currDir = Vector2.right; // default value is right

    private RaycastHit2D hit;

    public float patrolStandTime = 3.0f; // default value is 3s
    public float speed = 5.0f; // default value is 5.0
    public float patrolOffset = 5.0f; // default value is 5.0
    public float patrolRange = 5.0f; // default value is 5.0
    public float chaseRange = 7.0f; // default value is 7.0
    public float guardRange = 5.0f; // default value is 5.0
    private float patrolStandTimer;
    private float currRange;

    private int playerLayer;

    public bool isFacingRight = true; // default value is facing right
    public bool isJuggernaut;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        sprRend = GetComponent<SpriteRenderer>();

        originPos = transform.position;

        CurrState = initialState;

        patrolStandTimer = patrolStandTime;

        playerLayer = LayerMask.GetMask("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (isFacingRight)
        {
            currDir = Vector2.right;
            sprRend.flipX = false;
        }
        else
        {
            currDir = Vector2.left;
            sprRend.flipX = true;
        }

        ManageState();
	}

    // a method to run the current state
    private void ManageState()
    {
        switch (CurrState)
        {
            case EnemyState.PATROL:
                Invoke("Patrol", 0.5f);
                break;
            case EnemyState.CHASE:
                Invoke("Chase", 0.5f);
                break;
            case EnemyState.GUARD:
                Invoke("Guard", 0.5f);
                break;
            case EnemyState.ASLEEP:
                break;
        }
    }

    // a method for enemy patrol
    private void Patrol()
    {
        if (FoundPlayer())
        {
            CurrState = EnemyState.CHASE;
            return;
        }

        switch (patrolType)
        {
            case PatrolType.MONODIR:
                MonodirPatrol();
                break;
            case PatrolType.BIDIR:
                BidirPatrol();
                break;
        }
    }

    // a method for enemy one-directional patrol
    private void MonodirPatrol()
    {
        if (Mathf.Abs(originPos.x - transform.position.x) < patrolOffset)
        {
            Move();
        }
        else
        {
            if (patrolStandTimer > 0)
            {
                patrolStandTimer -= Time.deltaTime;
                anim.SetBool("Is Standing", true);
            }
            else
            {
                patrolStandTimer = patrolStandTime;
                originPos = transform.position;
                isFacingRight = !isFacingRight; // change direction
                anim.SetBool("Is Standing", false);
                Move();
            }
        }
    }

    // a method for enemy two-directional patrol
    private void BidirPatrol()
    {
        if (Mathf.Abs(originPos.x - transform.position.x) < patrolOffset)
        {
            Move();
        }
        else
        {
            if (patrolStandTimer > 0)
            {
                patrolStandTimer -= Time.deltaTime;
                anim.SetBool("Is Standing", true);
            }
            else
            {
                patrolStandTimer = patrolStandTime;
                isFacingRight = !isFacingRight; // change direction
                anim.SetBool("Is Standing", false);
                Move();
            }
        }
    }

    // a method for enemy chase
    private void Chase()
    {
        if (!FoundPlayer())
        {
            CurrState = initialState;
            anim.SetBool("Is Chasing", false);
            Physics2D.IgnoreLayerCollision(8, 10);
            return;
        }
        else
        {
            Vector3 currPos = transform.position;
            Vector3 targetPos = hit.transform.position;

            if (Mathf.Abs(targetPos.x - currPos.x) <= chaseRange)
            {
                if (targetPos.x - currPos.x < 0)
                {
                    isFacingRight = false;
                }
                else if (targetPos.x - currPos.x > 0)
                {
                    isFacingRight = true;
                }

                anim.SetBool("Is Chasing", true);
                Move();
            }
        }
    }

    // a method for enemy guard
    private void Guard()
    {
        if (FoundPlayer())
        {
            CurrState = EnemyState.CHASE;
            return;
        }
    }

    // a method to see if the player is within range
    private bool FoundPlayer()
    {
        RaycastHit2D tempHit = Physics2D.Raycast(transform.position, currDir, currRange, playerLayer);

        if (tempHit)
        {
            // if enemy is chasing, hiding will not save player
            if (currState == EnemyState.CHASE)
            {
                hit = tempHit;
                return true;
            }
            else if (!tempHit.transform.gameObject.GetComponent<Hide>().IsHiding)
            {
                hit = tempHit;
                return true;
            }
        }
        else
        {
            return false;
        }
        return false;
    }

    // a method for movement
    private void Move()
    {
        if (isFacingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // a method to make enemy fall asleep
    private void Sleep()
    {
        CurrState = EnemyState.ASLEEP;
    }
    
    // a method to handle enemy death
    private void Die()
    {
        levelStats.kills++;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.Defeat(true);
        }
    }

    /////// PROPERTIES ///////
    public EnemyState CurrState
    {
        get
        {
            return this.currState;
        }
        set
        {
            switch (value)
            {
                case EnemyState.PATROL:
                    currRange = patrolRange;
                    anim.SetBool("Is Patrolling", true);
                    break;
                case EnemyState.CHASE:
                    Physics2D.IgnoreLayerCollision(8, 10, false);
                    currRange = chaseRange;
                    anim.SetBool("Is Patrolling", false);
                    break;
                case EnemyState.GUARD:
                    currRange = guardRange;
                    anim.SetBool("Is Standing", true);
                    break;
            }
            this.currState = value;
        }
    }
}
