using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pistol Object", menuName = "Inventory System/Items/Pistol")]
public class PistolObject : ItemObject
{
    public ItemType ammoType;
    public int Damage;
    public float NextAttack;
    public int MagazineSize;
    public int ReserveAmmo;

    public void Awake()
    {
        type = ItemType.Pistol;
        ammoType = ItemType.PistolAmmo;
    }
}
