using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour, IInteractable<GameObject> {

    public GameObject destination;

    private Vector3 targetCoords;

    private void Start()
    {
        targetCoords = destination.transform.position;
    }

    public void Interact(GameObject player)
    {
        player.transform.position = targetCoords;
    }

    public Vector3 GetTargetCoords()
    {
        return targetCoords;
    }
}
