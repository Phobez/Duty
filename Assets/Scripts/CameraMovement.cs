using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    private Vector3 playerPos;
    private Vector3 cameraPos;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;
        cameraPos = new Vector3(playerPos.x, playerPos.y, -10);

        transform.position = cameraPos;
	}
}
