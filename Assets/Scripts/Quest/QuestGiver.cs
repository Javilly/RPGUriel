﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;

public class QuestGiver : MonoBehaviour {

    public BQuest quest;

    public Player player;

    private bool playerNear;

    public string questID = 1.ToString();

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text xpText;
    public Image itemImage;
    public Image stateImage;

    public Sprite iconNPC;


    void LoadQuest(string questID)
    {
        quest = JsonUtility.FromJson<BQuest>(Resources.Load<TextAsset>("Quests/" + questID).text);
    }
    


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        xpText.text = quest.xpReward.ToString() + " XP";
        itemImage.sprite = quest.itemReward.itemIcon;
    }


    public void OpenDialogWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        itemImage.sprite = iconNPC;
    }



    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }


    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.active = true;
        player.quest = quest;
    }



    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            playerNear = true;
        }
    }


    void OnTriggerExit2D(Collider2D c)
    {
        playerNear = false;
        CloseQuestWindow();
    }


    void Update()
    {
        if (playerNear)
        {
            LoadQuest(questID);
            OpenQuestWindow();
        }
        if (questWindow.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                AcceptQuest();
                print("Aceptase una Quest");
            }
        }
    }
}
