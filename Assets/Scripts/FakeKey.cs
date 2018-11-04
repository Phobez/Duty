using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeKey : MonoBehaviour
{

    public DemoLevelManager demoLevelManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            demoLevelManager.SetHasFakeKey(true);

            Destroy(gameObject);
        }
    }
}
