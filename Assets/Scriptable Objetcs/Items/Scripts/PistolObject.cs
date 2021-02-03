using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pistol Object", menuName = "Inventory System/Items/Pistol")]
public class PistolObject : ItemObject
{
    public SubType ItemSubType;
    public int Damage;
    public float NextAttack;
    public int MagazineSize;
    public int ReserveAmmo;

    public enum SubType
    {
        Pistol
    }
    public void Awake()
    {
        type = ItemType.Pistol;
    }
}
