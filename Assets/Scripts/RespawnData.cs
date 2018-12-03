using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RespawnData {

    private static byte currStage;
    private static bool hasRestarted;

    public static byte CurrStage
    {
        get
        {
            return currStage;
        }
        set
        {
            currStage = value;
        }
    }

    public static void Reset()
    {
        CurrStage = (byte)1;
    }

    /////// PROPERTIES ///////
    public static bool HasRestarted
    {
        get
        {
            return hasRestarted;
        }
        set
        {
            // Debug.Log("Has Restarted value modified");
            hasRestarted = value;
        }
    }
}
