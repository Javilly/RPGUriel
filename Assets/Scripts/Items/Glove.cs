﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : Item {


    public int itemAtk;
    public int itemSpeed;


    public Glove(string name, int id, string desc, Sprite sprite, int dmg, int speed, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = sprite;
        itemAtk = dmg;
        itemSpeed = speed;
        itemType = type;
    }
}
