using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedown : MonoBehaviour {

    private bool isTakingDown;

    private int enemyLayer;

	// Use this for initialization
	void Start () {
        isTakingDown = false;
        enemyLayer = LayerMask.GetMask("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1.0f, enemyLayer);

            if(hit)
            {
                Debug.Log("CHIYAA");
                Destroy(hit.transform.gameObject);
                isTakingDown = true;
            }
            else
            {
                isTakingDown = false;
            }
        }
	}
}
