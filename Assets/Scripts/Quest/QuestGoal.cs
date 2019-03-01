using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal{

    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool Isreached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void SlimeKill() //se puede poner como argumento el type de enemigo para saber si el enemigo que mataste es el de la quest
    {
        if(goalType == GoalType.slime)
        {
            currentAmount++;
        }       
    }

    public void FlyingKill() //lo mismo que para el enemigo
    {
        if (goalType == GoalType.flying)
        {
            currentAmount++;
        }
    }

    public void BossKill() //lo mismo que para el enemigo
    {
        if (goalType == GoalType.boss)
        {
            currentAmount++;
        }
    }

}

public enum GoalType
{
    slime,
    flying,
    boss
}