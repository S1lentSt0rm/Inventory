using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class ItemModel
{
    public ItemModelSO ItemModelSO;
    public float itemState;

    public ItemModel(ItemModelSO itemModelSO)
    {
        ItemModelSO = itemModelSO;
    }

}

[CreateAssetMenu]
public class ItemModelSO : ScriptableObject
{
    public string itemName;
    public Vector2 itemSize;
    public GameObject prefab;
}
