using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoundary : MonoBehaviour {

    public GameObject gameManager;
    public byte nextStage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<DemoLevelManager>().SetStage(nextStage);
        }
    }
}
