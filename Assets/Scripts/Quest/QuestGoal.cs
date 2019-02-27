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

    public void EnemyKill() //se puede poner como argumento el type de enemigo para saber si el enemigo que mataste es el de la quest
    {
        if(goalType == GoalType.kill)
        {
            currentAmount++;
        }
        
    }

    public void ItemGathered() //lo mismo que para el enemigo
    {
        if (goalType == GoalType.Gather)
        {
            currentAmount++;
        }

    }

}

public enum GoalType
{
    kill,
    Gather
}