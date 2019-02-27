﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item {

    public int gemElement;
    public int gemAbility;


    public Gem(string name, int id, string desc, Sprite sprite,int level, int element, int ability, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = sprite;
        itemLevel = level;
        gemElement = element;
        gemAbility = ability;
        itemType = type;
    }
}
