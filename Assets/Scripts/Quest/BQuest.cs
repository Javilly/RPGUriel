using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BQuest{

    public bool active;
    public bool finished;

    public string title;
    public string description;
    public int xpReward;
    public Item itemReward;

    public QuestGoal goal;

    public void Complete()
    {
        active = false;
        Debug.Log("Se terminó la quest: " + title);
    }
}
