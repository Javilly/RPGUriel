using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipement : MonoBehaviour {

    public List<Item> itemEquipment = new List<Item>();
    private ItemDatabase database;

    public Sprite defaultSprite;

    public Gem[] gemEquipment2 = new Gem[2];

    public Mineral[] mineralEquipment = new Mineral[2];

    public Image firstGem;
    public Image secondGem;

    public GameObject firstGemSlot;
    public GameObject secondGemSlot;

    private Item itemOP;

    public Player player;

    

    
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        gemEquipment2[0] = new Gem("", 0, "", defaultSprite, 0, 4, 4, Item.ItemType.Gem);
        gemEquipment2[1] = new Gem("", 0, "", defaultSprite, 0, 4, 4, Item.ItemType.Gem);

        mineralEquipment[0] = new Mineral("", 0, "", defaultSprite, 0, 0, 0, 0, Item.ItemType.Mineral);
        mineralEquipment[1] = new Mineral("", 0, "", defaultSprite, 0, 0, 0, 0, Item.ItemType.Mineral);
    }


    public void CheckStatsGem()
    {
        player.maxJumpQuantity = 1;
        player.canDash = false;

        if (gemEquipment2[0].gemAbility == 0 || gemEquipment2[1].gemAbility == 0)
        {
            player.maxJumpQuantity++;
        }
        if (gemEquipment2[0].gemAbility == 1 || gemEquipment2[1].gemAbility == 1)
        {
            player.canDash = true;
        }

    }

    public void CheckStatsMineral()
    {

    }

    public void EquipMineral(Mineral mineralToEquip)
    {
        mineralEquipment[1] = mineralEquipment[0];

        mineralEquipment[0] = mineralToEquip;

        CheckStatsMineral();

    }

    public void EquipGem(Gem gemToEquip, int slot)
    {

        gemEquipment2[1] = gemEquipment2[0];

        gemEquipment2[0] = gemToEquip;

        CheckStatsGem();
    }

    private void Update()
    {
        

        if (gemEquipment2.Length > 0)
        {
            firstGemSlot.SetActive(true);
            firstGem.sprite = gemEquipment2[0].itemIcon;



            if(gemEquipment2.Length > 1)
            {
                secondGemSlot.SetActive(true);
                secondGem.sprite = gemEquipment2[1].itemIcon;
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
}
