using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
    public List<Gem> gems = new List<Gem>();
    public List<Mineral> minerals = new List<Mineral>();
    public List<Glove> gloves = new List<Glove>();


    private void Awake()
    {
        print(JsonUtility.ToJson(gloves[0]));
    }
}
