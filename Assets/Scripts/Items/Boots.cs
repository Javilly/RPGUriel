using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Item {

    public int itemHP;


    public Boots(string name, int id, string desc, Sprite sprite,int level, int health, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = sprite;
        itemLevel = level;
        itemHP = health;
        itemType = type;
    }
}
