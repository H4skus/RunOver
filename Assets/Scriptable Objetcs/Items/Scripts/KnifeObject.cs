using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knife Object", menuName = "Inventory System/Items/Knife")]
public class KnifeObject : ItemObject
{
    
    public int damage;
    public void Awake()
    {
        type = ItemType.Knife;
    }
}
