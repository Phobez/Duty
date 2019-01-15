using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptController : MonoBehaviour {

    public GameObject c;

    private Collider2D[] player;

    private Vector3 currPos;

    public LayerMask targetLayer;

    private float offset;

	// Use this for initialization
	void Start () {
        c.SetActive(false);

        if (GetComponent<EnemyAI>().isFacingRight)
        {
            offset = -1.0f;
        }
        else
        {
            offset = 1.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<EnemyAI>().isFacingRight)
        {
            offset = -0.5f;
        }
        else
        {
            offset = 0.5f;
        }

        currPos = transform.position;
        currPos.x += offset;
        player = Physics2D.OverlapBoxAll(currPos, new Vector2(1, 1), 0, targetLayer);

        if (player.Length > 0)
        {
            Debug.Log("DETECTED!");
            c.SetActive(true);
        }
        else
        {
            c.SetActive(false);
        }
	}
}
