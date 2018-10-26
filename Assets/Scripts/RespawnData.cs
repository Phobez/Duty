using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RespawnData {

    private static byte currStage = (byte)1;
    private static bool hasRestarted = false;

    public static byte CurrStage
    {
        get
        {
            return currStage;
        }
        set
        {
            currStage = CurrStage;
        }
    }

    public static bool HasRestarted
    {
        get
        {
            return hasRestarted;
        }
        set
        {
            hasRestarted = HasRestarted;
        }
    }
}
