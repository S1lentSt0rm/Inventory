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
        InventoryModel.AddItemToInventory(new ItemModel(possibleItems[0]));
        InventoryModel.AddItemToInventory(new ItemModel(possibleItems[1]));
        InventoryModel.AddItemToInventory(new ItemModel(possibleItems[2]));
        
        InventoryModel.AddItemToDrop(new ItemModel(possibleItems[0]));
        InventoryModel.AddItemToDrop(new ItemModel(possibleItems[1]));
        InventoryModel.AddItemToDrop(new ItemModel(possibleItems[2]));
    }

    private void Update()
    {
        Debug.Log("Inventory item count: "+InventoryModel.inventoryItemList.Count);
        Debug.Log("Drop item count: "+InventoryModel.dropItemList.Count);
    }
}
