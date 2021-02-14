using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStats : MonoBehaviour
{
    public int health;
    public EnemyStat enemy;
    void Start()
    {
        health = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
