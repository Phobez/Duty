using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, IInteractable<GameObject> {

    public Trap[] traps;
    public bool on = true;

    public void Interact(GameObject obj)
    {
        Debug.Log("Called");
        On = !On;
    }

    public bool On
    {
        get
        {
            return on;
        }
        set
        {
            this.on = value;
            for (int i = 0; i < traps.Length; i++)
            {
                traps[i].On = this.on;
            }
        }
    }

}
