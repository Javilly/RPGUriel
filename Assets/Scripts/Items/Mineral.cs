using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mineral : Item {

    public int mineralAbility;



    public Mineral(string name, int id, string desc, Sprite sprite,int level, int ability, ItemType type, bool equiped)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = sprite;
        itemLevel = level;
        mineralAbility = ability;
        itemType = type;
        itemEquiped = equiped;
    }
}
