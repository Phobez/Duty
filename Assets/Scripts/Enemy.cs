using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    enum EnemyState : byte { PATROL, GUARD, CHASE, ASLEEP };

    public bool isStatic;
    public bool faceRight = true;
    private bool isFacingRight;

    protected Animator anim;

    protected SpriteRenderer sprRend;

    public GameManager gameManager;

    private RaycastHit2D hit;

    private Vector3 originPos;
    private Vector3 targetPos;

    private Vector2 currDir;

    private int playerLayer;

    private byte currState;

    public float speed = 5.0f;
    public float patrolOffset = 5.0f;
    public const float standTime = 3.0f;
    public const float patrolRange = 5.0f;
    public const float chaseRange = 7.5f;
    private float standTimer;
    private float currRange;

    // Use this for initialization
    void Start () {
        if (isStatic)
        {
            currState = (byte)EnemyState.GUARD;
        }
        else
        {
            currState = (byte)EnemyState.PATROL;
        }

        isFacingRight = faceRight;

        originPos = transform.position;

        playerLayer = LayerMask.GetMask("Player");

        standTimer = standTime;

        anim = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
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

        if (currState != (byte)EnemyState.ASLEEP)
        {
            hit = Physics2D.Raycast(transform.position, currDir, currRange, playerLayer);
            ManageState();


            if (hit)
            {
                targetPos = hit.transform.position;
                Hide hide = hit.transform.gameObject.GetComponent<Hide>();

                if (!hide.GetIsHiding())
                {
                    SetCurrState((byte)EnemyState.CHASE);
                    anim.SetBool("Is Patrolling", false);
                }
            }
            else if (currState != (byte)EnemyState.GUARD)
            {
                SetCurrState((byte)EnemyState.PATROL);
            }
            else if (isStatic)
            {
                SetCurrState((byte)EnemyState.GUARD);
            }
        }

        // Debug.Log(currState);
    }

    void Move()
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

    // a method to handle states
    void ManageState()
    {
        switch (currState)
        {
            case (byte)EnemyState.PATROL:
                Invoke("Patrol", 0.5f);
                break;
            case (byte)EnemyState.GUARD:
                break;
            case (byte)EnemyState.CHASE:
                Invoke("Chase", 0.5f);
                break;
            case (byte)EnemyState.ASLEEP:
                break;
        }
    }

    // a method to handle patrol
    void Patrol()
    {
        Vector3 currPos = transform.position;

        if (Mathf.Abs(currPos.x - originPos.x) >= patrolOffset)
        {
            if (standTimer > 0)
            {
                standTimer -= Time.deltaTime;
                anim.SetBool("Is Standing", true);
            }
            else
            {
                isFacingRight = !isFacingRight; // change directions
                anim.SetBool("Is Standing", false);
                Move();
                standTimer = standTime; // reset timer for next stand
            }
        }
        else
        {
            Move();
        }
    }

    void Chase()
    {
        Vector3 currPos = transform.position;

        if (Mathf.Abs(targetPos.x - currPos.x) <= 0.5f && Mathf.Abs(targetPos.y - currPos.y) <= 0.5f)
        {
            gameManager.Defeat();
        }
        else if (Mathf.Abs(targetPos.x - currPos.x) <= chaseRange)
        {
            if (targetPos.x - currPos.x < 0)
            {
                isFacingRight = false;
            }
            else if (targetPos.x - currPos.x > 0)
            {
                isFacingRight = true;
            }

            Move();
        }
        else
        {
            SetCurrState((byte)EnemyState.PATROL);
            anim.SetBool("Is Chasing", false);
        }
    }

    private void ChangeState()
    {
        switch (currState)
        {
            case (byte)EnemyState.PATROL:
                currRange = patrolRange;
                anim.SetBool("Is Patrolling", true);
                break;
            case (byte)EnemyState.GUARD:
                currRange = patrolRange;
                break;
            case (byte)EnemyState.CHASE:
                anim.SetBool("Is Chasing", true);
                currRange = chaseRange;
                break;
            case (byte)EnemyState.ASLEEP:
                break;
        }
    }

    public void SetCurrState(byte currState)
    {
        this.currState = currState;
        ChangeState();
    }

}