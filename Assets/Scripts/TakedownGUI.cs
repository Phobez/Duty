using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakedownGUI : MonoBehaviour
{

    public Sprite active;
    public Sprite inactive;

    private Takedown player;

    private Image img;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Takedown>();

        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.HasTakendown)
        {
            img.sprite = active;
        }
        else
        {
            img.sprite = inactive;
        }
    }
}
