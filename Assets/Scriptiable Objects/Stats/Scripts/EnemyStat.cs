using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stat", menuName = "Stat System/Enemy/EnemyStat")]
public class EnemyStat : Stats
{
    public int health;
    public float speed;
    public float NextAttack;
}
