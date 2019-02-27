using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEquipamiento : MonoBehaviour {

    private bool playerNear;
    public Inventory playerInventory;
    public Equipement playerEquipment;


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
        if (playerNear && Input.GetKeyDown(KeyCode.F))
        {
            //playerInventory.OpenInventory();
            //playerEquipment.OpenEquipment();
        }
    }
}
