using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour {

    public GameObject gameManager;
    private GameObject[] enemies;

    private RaycastHit2D hit;

    private Vector2 currDir;

    private int currDirFlag;
    private int playerLayer;

    public float searchTime = 3.0f;
    public float switchTime = 1.0f;
    private float searchTimer;
    private float switchTimer;

    // Use this for initialization
    void Start () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        currDir = Vector2.down;

        currDirFlag = 0;

        playerLayer = LayerMask.GetMask("Player");

        searchTimer = searchTime;
        switchTimer = switchTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (searchTimer > 0)
        {
            searchTimer -= Time.deltaTime;

            Debug.DrawRay(transform.position, currDir, Color.red);
            hit = Physics2D.Raycast(transform.position, currDir, 10.0f, playerLayer);

            if (hit)
            {
                gameManager.GetComponent<GameManager>().SetCurrState(2); // DEFEAT
            }
        }
        else if (searchTimer <= 0 && switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        else if (searchTimer <= 0 && switchTimer <= 0)
        {
            searchTimer = searchTime;
            switchTimer = switchTime;

            SwitchDir();
        }
	}

    void SwitchDir()
    {
        SwitchCurrDirFlag();

        switch (currDirFlag)
        {
            case -1:
                currDir = new Vector2(-0.5f, -0.5f);
                break;
            case 0:
                currDir = Vector2.down;
                break;
            case 1:
                currDir = new Vector2(0.5f, -0.5f);
                break;
        }
    }

    void SwitchCurrDirFlag()
    {
        currDirFlag--;

        if (currDirFlag < -1)
        {
            currDirFlag = 1;
        }
    }
}
