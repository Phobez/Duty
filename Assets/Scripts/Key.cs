using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public DemoLevelManager demoLevelManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            demoLevelManager.SetHasKey(true);

            Destroy(gameObject);
        }
    }
}
