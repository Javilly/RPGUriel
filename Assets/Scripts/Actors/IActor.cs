using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum baseAttribute
{
    Health,
    Damage,
    Mana,
    Defense,
}

public abstract class IActor{

    [SerializeField] protected int actorID;
    public int ID { get { return actorID; } }
    protected int level;
    protected Sprite actorSprite;

    protected float baseHealth;
    protected float baseDamage;
    protected float baseDefense;
    protected float baseMana;


    protected float currentHealth;
    protected float currentMana;
}
