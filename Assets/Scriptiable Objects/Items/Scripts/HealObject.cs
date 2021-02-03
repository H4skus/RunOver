using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Object", menuName = "Inventory System/Items/Heal")]
public class HealObject : ItemObject
{
    public int RestoreHealthValue;
    public void Awake()
    {
        type = ItemType.Heal;
    }
}
