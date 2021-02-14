using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemyMove : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        enemy.SetActive(true);
    }
}
