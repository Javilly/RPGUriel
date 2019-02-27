using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : Item {

    public int itemHP;
    public int itemAtkSpeed;
    public int itemDmg;



    public Mineral(string name, int id, string desc, Sprite sprite,int level, int health, int attackSpeed, int damage, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = sprite;
        itemLevel = level;
        itemHP = health;
        itemAtkSpeed = attackSpeed;
        itemDmg = damage;
        itemType = type;
    }
}
