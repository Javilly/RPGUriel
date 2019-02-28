using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;
    public Player player;
    public QuestGiver questGiver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void EnemyKill()
    {
        if (questGiver.quest.active)
        {
            questGiver.quest.goal.EnemyKill();
            if (questGiver.quest.goal.Isreached())
            {
                player.experience += questGiver.quest.xpReward;
                questGiver.quest.Complete();
            }
        }
    }


}
