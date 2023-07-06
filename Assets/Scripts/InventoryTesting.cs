using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InventoryTesting : MonoBehaviour
{
    public InventoryModel InventoryModel;
    public List<ItemModelSO> possibleItems;

    public int dropItemCount;

    private void Awake()
    {
        for (int i = 0; i < dropItemCount; i++)
        {
            var index = Random.Range(0, possibleItems.Count);
            InventoryModel.AddItemToDrop(new ItemModel(possibleItems[index]));
        }
    }

    private void Update()
    {
        Debug.Log("Inventory item count: "+InventoryModel.inventoryItemList.Count);
        Debug.Log("Drop item count: "+InventoryModel.dropItemList.Count);
    }
}
