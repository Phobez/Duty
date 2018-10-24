using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevelManager : MonoBehaviour {

    public Vector3 Stage2Pos;

    private enum LevelStates : byte {
        STAGE1 = 1,
        STAGE2,
        STAGE3
    };

    private LevelStates currStage;

    private bool hasChanged = false;

    private void Awake()
    {
        currStage = LevelStates.STAGE1;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (hasChanged == true)
        {
            switch (currStage)
            {
                case LevelStates.STAGE1:
                    break;
                case LevelStates.STAGE2:
                    GetComponentInParent<GameManager>().player.transform.position = Stage2Pos;
                    break;
                case LevelStates.STAGE3:
                    break;
            }

            hasChanged = false;
        }
	}

    public void SetStage(byte stage)
    {
        if (stage >= 1 && stage <= 3)
        {
            this.currStage = (LevelStates)stage;
            hasChanged = true;
        }
        else
        {
            Debug.Log("INVALID STAGE NUMBER");
        }
    }
}
