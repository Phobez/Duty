using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

    public static Game current;

    public bool[] levels;

    public Game()
    {
        levels = new bool[4];

        levels[0] = true;

        for (int i = 1; i < 4; i++)
        {
            levels[i] = false;
        }
    }
}
