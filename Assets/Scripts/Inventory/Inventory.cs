using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


    public List<Item> inventory = new List<Item>();

    public Item[] inventory2 = new Item[20];


    private ItemDatabase database;

    private bool UIActive;

    public GameObject inventoryUI;

    public Item selectedItem;

    private int selectedCounter = 0;

    public Image itemSlot1;
    public Image itemSlot2;
    public Image itemSlot3;
    public Image itemSlot4;
    public Image itemSlot5;
    public Image itemSlot6;
    public Image itemSlot7;
    public Image itemSlot8;
    public Image itemSlot9;
    public Image itemSlot10;
    public Image itemSlot11;
    public Image itemSlot12;
    public Image itemSlot13;
    public Image itemSlot14;
    public Image itemSlot15;
    public Image itemSlot16;
    public Image itemSlot17;
    public Image itemSlot18;
    public Image itemSlot19;
    public Image itemSlot20;


    public Text selectedItemName;
    public Text selectedItemType;
    public Text selectedItemLevel;


    // Use this for initialization
    void Start () {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        inventory.Add(database.items[0]);
	}


    public void PickupItem(Item itemPicked)
    {
        for (int i = 0; i < inventory2.Length; i++)
        {
            if(inventory2[i].itemIcon == null)
            {
                inventory2[i] = itemPicked;
                return;
            }
            if(i == 20)
            {
                return;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !UIActive)
        {
            inventoryUI.SetActive(true);

            itemSlot1.sprite = inventory2[0].itemIcon;
            itemSlot2.sprite = inventory2[1].itemIcon;
            itemSlot3.sprite = inventory2[2].itemIcon;
            itemSlot4.sprite = inventory2[3].itemIcon;
            itemSlot5.sprite = inventory2[4].itemIcon;
            itemSlot6.sprite = inventory2[5].itemIcon;
            itemSlot7.sprite = inventory2[6].itemIcon;
            itemSlot8.sprite = inventory2[7].itemIcon;
            itemSlot9.sprite = inventory2[8].itemIcon;
            itemSlot10.sprite = inventory2[9].itemIcon;
            itemSlot11.sprite = inventory2[10].itemIcon;
            itemSlot12.sprite = inventory2[11].itemIcon;
            itemSlot13.sprite = inventory2[12].itemIcon;
            itemSlot14.sprite = inventory2[13].itemIcon;
            itemSlot15.sprite = inventory2[14].itemIcon;
            itemSlot16.sprite = inventory2[15].itemIcon;
            itemSlot17.sprite = inventory2[16].itemIcon;
            itemSlot18.sprite = inventory2[17].itemIcon;
            itemSlot19.sprite = inventory2[18].itemIcon;
            itemSlot20.sprite = inventory2[19].itemIcon;


            UIActive = true;

        }
        else if(Input.GetKeyDown(KeyCode.I) && UIActive)
        {
            inventoryUI.SetActive(false);
            UIActive = false;
            selectedCounter = 0;
        }

        if (UIActive)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                selectedCounter++;
                if (selectedCounter == 20)
                {
                    selectedCounter = 0;
                }
                selectedItem = inventory2[selectedCounter];
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                selectedCounter--;
                if (selectedCounter < 0)
                {
                    selectedCounter = 19;
                }
                selectedItem = inventory2[selectedCounter];
            }

            selectedItemName.text = selectedItem.itemName;
            selectedItemType.text = selectedItem.itemType.ToString();
            selectedItemLevel.text = selectedItem.itemLevel.ToString();
        }

    }
}
