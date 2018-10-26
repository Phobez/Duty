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

    private enum LevelStates : byte {
        STAGE1 = 1,
        STAGE2,
        STAGE3
    };

    [SerializeField] private LevelStates currStage = LevelStates.STAGE1;

    private bool hasChanged = false;
    private bool hasKey = false;

    // Use this for initialization
    void Start () {
        if (RespawnData.HasRestarted == true)
        {
            currStage = (LevelStates) RespawnData.CurrStage;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (hasChanged == true || RespawnData.HasRestarted == true)
        {
            switch (currStage)
            {
                case LevelStates.STAGE1:
                    GetComponentInParent<GameManager>().player.transform.position = Stage1Pos;
                    break;
                case LevelStates.STAGE2:
                    Stage2();
                    GetComponentInParent<GameManager>().player.transform.position = Stage2Pos;
                    break;
                case LevelStates.STAGE3:
                    Stage3();
                    GetComponentInParent<GameManager>().player.transform.position = Stage3Pos;
                    break;
            }

            hasChanged = false;
            RespawnData.HasRestarted = false;
        }
	}

    void Stage2()
    {
        Debug.Log("Called!");
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
}
