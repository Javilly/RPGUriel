using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;
    public Player player;
    public QuestGiver questGiver;
    public Inventory inventory;

    public GameObject mageNPC;

    public Transform magePosition1;
    public Transform magePosition2;
    public Transform magePosition3;

    public Item questReward;

    private int posMage = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    public void SlimeKill()
    {
        if (questGiver.quest.active)
        {
            questGiver.quest.goal.SlimeKill();
            print(questGiver.quest.goal.currentAmount + " / " + questGiver.quest.goal.requiredAmount);
            if (questGiver.quest.goal.Isreached())
            {
                if (posMage == 1)
                {
                    mageNPC.transform.position = magePosition2.position;
                    player.EquipNewGlove(posMage + 1);

                }
                else if (posMage == 2)
                {
                    mageNPC.transform.position = magePosition3.position;
                    player.EquipNewGlove(posMage + 1);
                }else if (posMage == 3)
                {
                    mageNPC.transform.position = magePosition1.position;
                    player.EquipNewGlove(posMage + 1);
                }
                questGiver.stateGO.SetActive(false);
                questGiver.questLoaded = false;
                questGiver.questID++;
                player.experience += questGiver.quest.xpReward;
                //print("JsonItems/" + questGiver.quest.itemReward.itemType + "/" + questGiver.quest.itemReward.itemName);
                questReward = JsonUtility.FromJson<Item>(Resources.Load<TextAsset>("JsonItems/" + questGiver.quest.itemReward.itemType + "/" + questGiver.quest.itemReward.itemName).text);
                inventory.PickupItem(questReward);
                questGiver.quest.Complete();
            }
        }
    }

    public void FlyingKill()
    {
        if (questGiver.quest.active)
        {
            questGiver.quest.goal.FlyingKill();
            if (questGiver.quest.goal.Isreached())
            {
                player.experience += questGiver.quest.xpReward;
                inventory.PickupItem(questGiver.quest.itemReward);
                questGiver.quest.Complete();
            }
        }
    }


}
