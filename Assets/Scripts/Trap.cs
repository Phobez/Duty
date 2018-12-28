using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public enum TrapType { KILL, ALARM };

    public TrapType trapType;

    private bool on = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (on)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
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
        }
    }
}
