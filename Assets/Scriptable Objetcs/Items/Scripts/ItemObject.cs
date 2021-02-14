using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Coin,
    Equipment,
    Heal,
    Pistol,
    PistolAmmo,
    Knife,
    Weapon,
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public int DropChance;
    public bool isDropable;
    public GameObject prefab;
}
[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public GameObject prefab;
    public ItemType itemType;

    public Item()
    {
        Name = "";
        Id = -1;
        prefab = null;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        prefab = item.prefab;
        itemType = item.type;
    }
}
