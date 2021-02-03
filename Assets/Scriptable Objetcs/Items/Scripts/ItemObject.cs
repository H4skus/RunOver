using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Coin,
    Equipment,
    Heal,
    Weapon,
    Ammo
}

public enum ItemSubType
{
    PistolAmmo
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    public ItemSubType subType;
    [TextArea(15,20)]
    public string description;
}
[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}
