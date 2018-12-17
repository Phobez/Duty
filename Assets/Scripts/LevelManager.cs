using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public LevelStats levelStats;

    private Takedown player;

    private float levelTimer;
    private float initialTakedownCooldown;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Takedown>();
        initialTakedownCooldown = player.takedownCooldown;

        if (PlayerPrefs.GetInt("Takedown", 0) == 1)
        {
            player.takedownCooldown = 0;
        }
        else if (PlayerPrefs.GetInt("Takedown", 0) == 0)
        {
            player.takedownCooldown = initialTakedownCooldown;
        }

        SetUpLevelStats();

        levelTimer = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrGameState == GameManager.GameState.PLAYING)
        {
            levelTimer += Time.deltaTime;
            levelStats.levelTime = levelTimer;
        }
    }

    // a method to set up the level stat scriptable object at level start
    protected void SetUpLevelStats()
    {
        levelStats.kills = 0;
        levelStats.levelTime = 0;
    }
}
