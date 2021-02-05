using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public MouseItem MouseItem = new MouseItem();

    public int health;
    public EnemyStat stats;

    private void Start()
    {
        health = stats.health;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item (item.item), 1);
            Destroy(other.gameObject);
        }
    }
}
