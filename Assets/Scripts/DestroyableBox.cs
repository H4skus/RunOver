using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBox : MonoBehaviour
{
    public GameObject coin;
    public int health = 40;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(coin, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
