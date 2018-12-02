using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public LevelStats levelStats;

    private void Start()
    {
        SetUpLevelStats();
    }

    // a method to set up the level stat scriptable object at level start
    protected void SetUpLevelStats()
    {
        levelStats.kills = 0;
    }
}
