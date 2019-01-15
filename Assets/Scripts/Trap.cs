using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public enum TrapType { KILL, ALARM };

    public TrapType trapType;

    public Sprite alarmSprite;
    public Sprite killSprite;
    public Sprite offSprite;

    private bool on = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (trapType == TrapType.KILL)
        {
            GetComponent<SpriteRenderer>().sprite = killSprite;
        }
        else if (trapType == TrapType.ALARM)
        {
            GetComponent<SpriteRenderer>().sprite = alarmSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (on)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                audioSource.Play();
                if (trapType == TrapType.KILL)
                {
                    GameManager.Instance.Defeat(true);
                }
                else if (trapType == TrapType.ALARM)
                {
                    Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, new Vector2(14, 1), 0, LayerMask.GetMask("Enemy"));

                    foreach (Collider2D enemy in enemies)
                    {
                        enemy.SendMessage("ChaseTarget", collision.gameObject);
                    }
                }
            }
        }
    }

    public bool On
    {
        get
        {
            return on;
        }
        set
        {
            this.on = value;
            if (value == false)
            {
                GetComponent<SpriteRenderer>().sprite = offSprite;
            }
        }
    }
}
