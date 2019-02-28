using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEquipamiento : MonoBehaviour {

    private bool playerNear = false;
    public Inventory playerInventory;
    public Equipement playerEquipment;

    private Gem selectedGem;
    private Mineral selectedMineral;


    void Start()
    {
        Invoke("RandomRotate", 0.5f);
    }

    void RandomRotate()
    {
        float randomTime = Random.Range(3, 7);

        bool reverse = false;

        if (reverse)
        {
            transform.Rotate(Vector3.up * 180);
        }
        else
        {
            transform.Rotate(Vector3.up * 180);
        }


        Invoke("RandomRotate", randomTime);

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
    }

    void Update()
    {
        if (playerNear)
        {

            playerInventory.UIActive = false;
            playerInventory.OpenInventory();

            if (Input.GetKeyDown(KeyCode.F))
            {
                if(playerInventory.selectedItem.itemType == Item.ItemType.Gem)
                {
                    selectedGem = (Gem)playerInventory.selectedItem;
                    playerEquipment.EquipGem(selectedGem);

                }else if(playerInventory.selectedItem.itemType == Item.ItemType.Mineral)
                {
                    selectedMineral = (Mineral)playerInventory.selectedItem;
                    playerEquipment.EquipMineral(selectedMineral);
                }
            }

        }else if (!playerNear)
        {
            if (!playerInventory.UIActive)
            {
                playerInventory.UIActive = true;
                playerInventory.CloseInventory();
            }
            
        }
    }
}
