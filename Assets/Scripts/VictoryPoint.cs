using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour {

    public int nextLevelId;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game.current.levels[nextLevelId] = true;
            SaveLoad.Save();
            GameManager.Instance.Victory(true);
        }
    }
}
