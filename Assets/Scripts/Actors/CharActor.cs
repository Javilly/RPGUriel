using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum c_class
{
    Swift,
    Heavy
}


[System.Serializable]
public class CharacterActor : IActor
{
    [SerializeField] c_class charClass;
    [SerializeField] float experience;
}