using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  Item
{
    void Use(GameObject _sender);
    ItemData GetData();
}
