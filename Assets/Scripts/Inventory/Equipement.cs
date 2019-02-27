using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipement : MonoBehaviour {

    public List<Item> itemEquipment = new List<Item>();
    public List<Gem> gemEquipment = new List<Gem>();
    private ItemDatabase database;

    public Image firstGem;
    public Image secondGem;

    public GameObject firstGemSlot;
    public GameObject secondGemSlot;

    private Item itemOP;



    
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    }


    private void Update()
    {
        if(gemEquipment.Count > 0)
        {
            firstGemSlot.SetActive(true);
            firstGem.sprite = gemEquipment[0].itemIcon;

            if(gemEquipment.Count > 1)
            {
                secondGemSlot.SetActive(true);
                secondGem.sprite = gemEquipment[1].itemIcon;
            }
            else
            {
                secondGemSlot.SetActive(false);
            }
        }
        else
        {
            firstGemSlot.SetActive(false);
        }
    }

    private void OnGUI()
    {
        {
            for (int i = 0; i < itemEquipment.Count; i++)
            {
                GUI.DrawTexture(new Rect(10, i * 20, 200, 50), itemEquipment[i].itemIcon.texture);
            }
        }
    }
}
