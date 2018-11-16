using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipement : MonoBehaviour {

    public List<Item> equipment = new List<Item>();
    private ItemDatabase database;

    // Use this for initialization
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    }

    private void OnGUI()
    {
        {
            for (int i = 0; i < equipment.Count; i++)
            {
                GUI.DrawTexture(new Rect(10, i * 20, 200, 50), equipment[i].itemIcon.texture);
            }
        }
    }
}
