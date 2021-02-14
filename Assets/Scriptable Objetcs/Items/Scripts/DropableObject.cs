using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableObject : MonoBehaviour
{
    public List<ItemObject> items = new List<ItemObject>();
    private void Start()
    {

    }
    public GameObject DropFromEnemy(int chance)
    {
        List<GameObject> inChance = new List<GameObject>();
        for (int i = 0; i < items.Count; i++)
        {
            if (chance<= items[i].DropChance && items[i].isDropable)
            {
                inChance.Add(items[i].prefab);
            }
        }
        return inChance[Random.Range(0,inChance.Count)];
    }
}