using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevelManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject Stage2Panel;
    public GameObject Stage3Panel;
    public GameObject truck;
    public Vector3 Stage1Pos;
    public Vector3 Stage2Pos;
    public Vector3 Stage3Pos;

    private GameObject player;

    private enum LevelStates : byte {
        STAGE1 = 1,
        STAGE2,
        STAGE3
    };

    [SerializeField] private LevelStates currStage;

    private bool hasChanged = false;
    private bool hasKey = false;
    private bool hasFakeKey = false;

    // Use this for initialization
    void Awake () {
        Debug.Log("Demo Level: " + RespawnData.HasRestarted);
        Debug.Log("Demo Level: " + RespawnData.CurrStage);

        Physics2D.IgnoreLayerCollision(8, 10);

        player = GameObject.FindGameObjectWithTag("Player");

        if (RespawnData.HasRestarted == true)
        {
            currStage = (LevelStates) RespawnData.CurrStage;
            switch (currStage)
            {
                case LevelStates.STAGE1:
                    Debug.Log("STAGE 1");
                    player.transform.position = Stage1Pos;
                    break;
                case LevelStates.STAGE2:
                    Debug.Log("STAGE 2");
                    Stage2();
                    player.transform.position = Stage2Pos;
                    break;
                case LevelStates.STAGE3:
                    Debug.Log("STAGE 3");
                    Stage3();
                    player.transform.position = Stage3Pos;
                    break;
            }

            RespawnData.HasRestarted = false;
        }
        else
        {
            currStage = LevelStates.STAGE1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (hasChanged == true)
        {
            switch (currStage)
            {
                case LevelStates.STAGE1:
                    Debug.Log("STAGE 1");
                    player.transform.position = Stage1Pos;
                    break;
                case LevelStates.STAGE2:
                    Debug.Log("STAGE 2");
                    Stage2();
                    player.transform.position = Stage2Pos;
                    break;
                case LevelStates.STAGE3:
                    Debug.Log("STAGE 3");
                    Stage3();
                    player.transform.position = Stage3Pos;
                    break;
            }

            hasChanged = false;
        }
	}

    void Stage2()
    {
        Stage2Panel.SetActive(true);
    }

    void Stage3()
    {
        Stage3Panel.SetActive(true);
    }

    public void SetStage(byte stage)
    {
        if (stage >= 1 && stage <= 3)
        {
            this.currStage = (LevelStates)stage;
            RespawnData.CurrStage = (byte)this.currStage;
            hasChanged = true;
        }
        else
        {
            Debug.Log("INVALID STAGE NUMBER");
        }
    }

    public void SetHasKey(bool hasKey)
    {
        this.hasKey = hasKey;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }

    public void SetHasFakeKey(bool hasFakeKey)
    {
        this.hasFakeKey = hasFakeKey;
    }

    public bool GetHasFakeKey()
    {
        return hasFakeKey;
    }
}
