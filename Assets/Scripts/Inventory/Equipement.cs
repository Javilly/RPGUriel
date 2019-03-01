using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipement : MonoBehaviour {



    public List<Item> itemEquipment = new List<Item>();
    private ItemDatabase database;


    //default Sprite for empty UI slots
    public Sprite defaultSprite;


    //Equipment storages for 2 gems and 2 minerals
    public Gem[] gemEquipment2 = new Gem[2];
    public Mineral[] mineralEquipment = new Mineral[2];


    //UI Gems
    public Image firstGem;
    public Image secondGem;
    public GameObject firstGemSlot;
    public GameObject secondGemSlot;

    //UI Minerals
    public Image firstMineral;
    public Image secondMineral;
    public GameObject firstMineralSlot;
    public GameObject secondMineralSlot;


    public Player player;



    public static Equipement instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        gemEquipment2[0] = new Gem("", 0, "", defaultSprite, 0, 4, 4, Item.ItemType.Gem, true);
        gemEquipment2[1] = new Gem("", 0, "", defaultSprite, 0, 4, 4, Item.ItemType.Gem, true);

        mineralEquipment[0] = new Mineral("", 0, "", defaultSprite, 0, 0, Item.ItemType.Mineral, true);
        mineralEquipment[1] = new Mineral("", 0, "", defaultSprite, 0, 0, Item.ItemType.Mineral, true);
    }


    public void CheckStatsGem()
    {
        player.maxJumpQuantity = 1;
        player.canDash = false;

        if (gemEquipment2[0].gemAbility == 0 || gemEquipment2[1].gemAbility == 0)
        {
            player.maxJumpQuantity++;
        }
        else if (gemEquipment2[0].gemAbility == 1 || gemEquipment2[1].gemAbility == 1)
        {
            player.canDash = true;
        }
        else if (gemEquipment2[0].gemAbility == 2 || gemEquipment2[1].gemAbility == 2)
        {
            //Poder para el Rubi
        }

    }

    public void CheckStatsMineral()
    {
        player.maxHealth = player.initialMaxHealth;
        player.damage = player.initialDamage;
        player.attackSpeed = player.initialAtkSpeed;

        if (mineralEquipment[0].mineralAbility == 0)
        {
            player.maxHealth += 50;
            if (mineralEquipment[1].mineralAbility == 0)
            {
                player.maxHealth += 50;
            }

        }
        else if (mineralEquipment[0].mineralAbility == 1)
        {
            player.damage += 10;
            if (mineralEquipment[1].mineralAbility == 1)
            {
                player.damage += 10;
            }

        }else if (mineralEquipment[0].mineralAbility == 2)
        {
            player.attackSpeed += 1;
            if (mineralEquipment[1].mineralAbility == 2)
            {
                player.attackSpeed += 1;
            }
        }
    }

    public void EquipMineral(Mineral mineralToEquip)
    {
        mineralEquipment[1] = mineralEquipment[0];

        mineralEquipment[0] = mineralToEquip;

        CheckStatsMineral();

    }

    public void EquipGem(Gem gemToEquip)
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



        if (mineralEquipment.Length > 0)
        {
            firstMineralSlot.SetActive(true);
            firstMineral.sprite = mineralEquipment[0].itemIcon;

            if (mineralEquipment.Length > 1)
            {
                secondMineralSlot.SetActive(true);
                secondMineral.sprite = mineralEquipment[1].itemIcon;
            }
            else
            {
                secondMineralSlot.SetActive(false);
            }
        }
        else
        {
            firstMineralSlot.SetActive(false);
        }
    }
}
