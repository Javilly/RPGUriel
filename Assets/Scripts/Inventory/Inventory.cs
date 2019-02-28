using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Item[] inventory2 = new Item[20];

    public List<GameObject> slots = new List<GameObject>();

    public bool UIActive;

    public GameObject inventoryUI;

    public Item selectedItem;

    private int selectedCounter = 0;

    public GameObject selector;

    public GameObject itemSlot1GO;
    public GameObject itemSlot2GO;
    public GameObject itemSlot3GO;
    public GameObject itemSlot4GO;
    public GameObject itemSlot5GO;
    public GameObject itemSlot6GO;
    public GameObject itemSlot7GO;
    public GameObject itemSlot8GO;
    public GameObject itemSlot9GO;
    public GameObject itemSlot10GO;
    public GameObject itemSlot11GO;
    public GameObject itemSlot12GO;
    public GameObject itemSlot13GO;
    public GameObject itemSlot14GO;
    public GameObject itemSlot15GO;
    public GameObject itemSlot16GO;
    public GameObject itemSlot17GO;
    public GameObject itemSlot18GO;
    public GameObject itemSlot19GO;
    public GameObject itemSlot20GO;

    private Image itemSlot1;
    private Image itemSlot2;
    private Image itemSlot3;
    private Image itemSlot4;
    private Image itemSlot5;
    private Image itemSlot6;
    private Image itemSlot7;
    private Image itemSlot8;
    private Image itemSlot9;
    private Image itemSlot10;
    private Image itemSlot11;
    private Image itemSlot12;
    private Image itemSlot13;
    private Image itemSlot14;
    private Image itemSlot15;
    private Image itemSlot16;
    private Image itemSlot17;
    private Image itemSlot18;
    private Image itemSlot19;
    private Image itemSlot20;



    public Text selectedItemName;
    public Text selectedItemType;
    public Text selectedItemLevel;


    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        itemSlot1 = itemSlot1GO.GetComponent<Image>();
        itemSlot2 = itemSlot2GO.GetComponent<Image>();
        itemSlot3 = itemSlot3GO.GetComponent<Image>();
        itemSlot4 = itemSlot4GO.GetComponent<Image>();
        itemSlot5 = itemSlot5GO.GetComponent<Image>();
        itemSlot6 = itemSlot6GO.GetComponent<Image>();
        itemSlot7 = itemSlot7GO.GetComponent<Image>();
        itemSlot8 = itemSlot8GO.GetComponent<Image>();
        itemSlot9 = itemSlot9GO.GetComponent<Image>();
        itemSlot10 = itemSlot10GO.GetComponent<Image>();
        itemSlot11 = itemSlot11GO.GetComponent<Image>();
        itemSlot12 = itemSlot12GO.GetComponent<Image>();
        itemSlot13 = itemSlot13GO.GetComponent<Image>();
        itemSlot14 = itemSlot14GO.GetComponent<Image>();
        itemSlot15 = itemSlot15GO.GetComponent<Image>();
        itemSlot16 = itemSlot16GO.GetComponent<Image>();
        itemSlot17 = itemSlot17GO.GetComponent<Image>();
        itemSlot18 = itemSlot18GO.GetComponent<Image>();
        itemSlot19 = itemSlot19GO.GetComponent<Image>();
        itemSlot20 = itemSlot20GO.GetComponent<Image>();

        slots.Add(itemSlot1GO);
        slots.Add(itemSlot2GO);
        slots.Add(itemSlot3GO);
        slots.Add(itemSlot4GO);
        slots.Add(itemSlot5GO);
        slots.Add(itemSlot6GO);
        slots.Add(itemSlot7GO);
        slots.Add(itemSlot8GO);
        slots.Add(itemSlot9GO);
        slots.Add(itemSlot10GO);
        slots.Add(itemSlot11GO);
        slots.Add(itemSlot12GO);
        slots.Add(itemSlot13GO);
        slots.Add(itemSlot14GO);
        slots.Add(itemSlot15GO);
        slots.Add(itemSlot16GO);
        slots.Add(itemSlot17GO);
        slots.Add(itemSlot18GO);
        slots.Add(itemSlot19GO);
        slots.Add(itemSlot20GO);
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


    public void OpenInventory()
    {
        inventoryUI.SetActive(!UIActive);
        UIActive = true;
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(!UIActive);
        UIActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !UIActive)
        {
            //inventoryUI.SetActive(true);

            OpenInventory();

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


        }
        else if(Input.GetKeyDown(KeyCode.I) && UIActive)
        {
            //inventoryUI.SetActive(false);
            CloseInventory();
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

            selector.transform.position = slots[selectedCounter].transform.position;
            selectedItemName.text = selectedItem.itemName;
            selectedItemType.text = selectedItem.itemType.ToString();
            selectedItemLevel.text = selectedItem.itemLevel.ToString();
        }

    }
}
