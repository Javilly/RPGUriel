﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public int itemLevel;
    public ItemType itemType;
    public bool itemEquiped;


    public enum ItemType
    {
        Gem,
        Glove,
        Potion,
        Mineral,
        Empty
    }
}
