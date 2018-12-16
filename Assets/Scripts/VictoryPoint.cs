using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour, IInteractable<GameObject> {

	public void Interact(GameObject player)
    {
        GameManager.Instance.Victory(true);
    }
}
