using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public new string name = "";
    public string description = "";
    public Sprite image = null;
    public GameObject prefab = null;
}
