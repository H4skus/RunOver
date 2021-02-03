using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PistolAmo Object", menuName = "Inventory System/Items/PistolAmo")]
public class AmmoObject : ItemObject
{

    public float Amount = 6;
    public void Awake()
    {
        type = ItemType.PistolAmmo;
        //subType = ItemSubType.PistolAmmo;
    }
}
