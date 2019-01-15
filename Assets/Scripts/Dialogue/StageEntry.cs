using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEntry : MonoBehaviour
{

    private float dialogueTimer = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueTimer <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            dialogueTimer -= Time.deltaTime;
        }
    }
}
