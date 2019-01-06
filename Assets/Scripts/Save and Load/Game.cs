using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

    public static Game current;

    public bool[] levels;

    public Game()
    {
        levels = new bool[5];

        levels[0] = true;

        for (int i = 1; i < 5; i++)
        {
            levels[i] = false;
        }
    }
}
