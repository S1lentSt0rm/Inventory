using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class ItemModel
{
    public ItemModelSO ItemModelSO;
    public float itemState;
    public ItemView ItemView;

    public ItemModel(ItemModelSO itemModelSO)
    {
        ItemModelSO = itemModelSO;
    }
    
    public string Serialize()
    {
        return JsonUtility.ToJson(this);
    }

    public static ItemModel Deserialize(string json)
    {
        return JsonUtility.FromJson<ItemModel>(json);
    }

}

[CreateAssetMenu]
public class ItemModelSO : ScriptableObject
{
    public string itemName;
    public Vector2Int itemSize;
    public GameObject prefab;
}
