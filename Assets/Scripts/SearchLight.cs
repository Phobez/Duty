using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour {

    public GameObject gameManager;

    private RaycastHit2D hit;

    private Vector2 currDir;

    private int currDirFlag;
    private int playerLayer;

    public float searchTime = 3.0f;
    private float searchTimer;

    // Use this for initialization
    void Start () {

        currDir = Vector2.down;

        currDirFlag = 0;

        playerLayer = LayerMask.GetMask("Player");

        searchTimer = searchTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (searchTimer > 0)
        {
            searchTimer -= Time.deltaTime;

            // Debug.DrawRay(transform.position, currDir * 6.0f, Color.red);
            hit = Physics2D.Raycast(transform.position, currDir, 10.0f, playerLayer);

            if (hit)
            {
                gameManager.GetComponent<GameManager>().SetCurrState(2); // DEFEAT
            }
        }
        else
        {
            SwitchDir();
            searchTimer = searchTime;
        }
	}

    void SwitchDir()
    {
        SwitchCurrDirFlag();

        switch (currDirFlag)
        {
            case -1:
                currDir = new Vector2(-0.5f, -0.5f);
                transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case 0:
                currDir = Vector2.down;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                currDir = new Vector2(0.5f, -0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 45f);
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
