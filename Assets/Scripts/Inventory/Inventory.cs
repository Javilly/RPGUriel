using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public List<Item> inventory = new List<Item>();
    private ItemDatabase database;

    // Use this for initialization
    void Start () {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        inventory.Add(database.items[0]);
	}

    private void OnGUI()
    {
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                GUI.Label(new Rect(800, i * 20, 200, 800), inventory[i].itemName);
            }
        }
    }
}
