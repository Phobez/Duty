using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoundary : MonoBehaviour {

    public GameObject gameManager;
    public byte nextStage;
    public bool doesTransport;
    public bool isLeftBoundary;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<DemoLevelManager>().SetStage(nextStage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (doesTransport)
            {
                gameManager.GetComponent<DemoLevelManager>().SetStage(nextStage);
            }
            else
            {
                if (isLeftBoundary)
                {
                    if (collision.gameObject.transform.position.x < transform.position.x)
                    {
                        collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, 0);
                    }
                }
                else
                {
                    if (collision.gameObject.transform.position.x > transform.position.x)
                    {
                        collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, 0);
                    }
                }
            }
        }
    }
}
