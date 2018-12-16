using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hideable : MonoBehaviour {

    public GameObject e;

    public void Start()
    {
        e.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            e.SetActive(true);
        }
    }
}
