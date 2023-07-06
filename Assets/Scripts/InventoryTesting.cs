using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    public InventoryModel InventoryModel;
    public List<ItemModelSO> possibleItems;

    private void Awake()
    {
        InventoryModel.dropItemList.Add(new ItemModel(possibleItems[0]));
        InventoryModel.dropItemList.Add(new ItemModel(possibleItems[1]));
        InventoryModel.dropItemList.Add(new ItemModel(possibleItems[2]));
    }
}
