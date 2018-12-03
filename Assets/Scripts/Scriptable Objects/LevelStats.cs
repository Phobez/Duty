using System;
using UnityEngine;

[CreateAssetMenu()]
public class LevelStats : ScriptableObject {
    [NonSerialized] public int kills;
    [NonSerialized] public float levelTime;
}
