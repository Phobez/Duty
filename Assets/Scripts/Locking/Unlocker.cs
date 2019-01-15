using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Made by : Abia Putrama Herlianto
 *           3 January 2019
 * SEE ALSO: Locking.cs
 */

// a component to creates an object that can unlock a designated locked object
public class Unlocker : MonoBehaviour {

    public enum UnlockerType { BUTTON, KEY };

    public Locking lockedObject;
    public UnlockerType unlockerType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (unlockerType == UnlockerType.KEY)
        {
            lockedObject.SendMessage("Unlock");
            Destroy(gameObject);
        }
        else if (unlockerType == UnlockerType.BUTTON)
        {
            lockedObject.SendMessage("Unlock");
        }
    }
}
