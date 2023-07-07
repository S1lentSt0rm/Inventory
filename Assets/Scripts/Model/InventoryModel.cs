using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class InventoryModel : MonoBehaviour
{
    public Vector2Int inventorySize;
    public InventorySlotStatus[,] Inventory;

     public struct PlacedItem
     {
         public Vector2Int ItemGridPosition;
         public ItemModel ItemModel;
    
         public PlacedItem(Vector2Int position, ItemModel itemModel)
         {
             ItemGridPosition = position;
             this.ItemModel = itemModel;
         }
     }
    public List<PlacedItem> InventoryItemList = new List<PlacedItem>();
    public List<ItemModel> dropItemList = new List<ItemModel>();

    private void Awake()
    {
        LoadInventoryData();
        Inventory = new InventorySlotStatus[inventorySize.x, inventorySize.y];
        foreach (var item in InventoryItemList)
        {
            Inventory[item.ItemGridPosition.x, item.ItemGridPosition.y] = InventorySlotStatus.Full;
        }
    }

    public void SaveInventoryData()
    {
        var inventoryData = new InventoryData
        {
            inventorySize = inventorySize
        };

        var serializedInventoryItems = new List<PlacedItemData>();
        foreach (var placedItem in InventoryItemList)
        {
            var placedItemData = new PlacedItemData
            {
                itemGridPosition = placedItem.ItemGridPosition,
                itemModelJson = placedItem.ItemModel.Serialize()
            };
            serializedInventoryItems.Add(placedItemData);
        }
        inventoryData.inventoryItemList = serializedInventoryItems.ToArray();
        
        var serializedDropItems = new List<string>();
        foreach (var dropItem in dropItemList)
        {
            serializedDropItems.Add(dropItem.Serialize());
        }
        inventoryData.dropItemList = new List<string>(serializedDropItems);

        var json = JsonUtility.ToJson(inventoryData);
        File.WriteAllText("inventoryData.json", json);
    }
    
    public void LoadInventoryData()
    {
        if (!File.Exists("inventoryData.json"))
        {
            return;
        }
        var json = File.ReadAllText("inventoryData.json");
        var inventoryData = JsonUtility.FromJson<InventoryData>(json);
        
        inventorySize = inventoryData.inventorySize;

        InventoryItemList.Clear();
        foreach (var placedItemData in inventoryData.inventoryItemList)
        {
            var placedItem = new PlacedItem
            {
                ItemGridPosition = placedItemData.itemGridPosition,
                ItemModel = ItemModel.Deserialize(placedItemData.itemModelJson)
            };
            InventoryItemList.Add(placedItem);
        }
        
        dropItemList.Clear();
        foreach (var serializedDropItem in inventoryData.dropItemList)
        {
            var dropItem = ItemModel.Deserialize(serializedDropItem);
            dropItemList.Add(dropItem);
        }
    }
}

[System.Serializable]
public class InventoryData
{
    public Vector2Int inventorySize;
    public PlacedItemData[] inventoryItemList;
    public List<string> dropItemList;
}

[System.Serializable]
public class PlacedItemData
{
    public Vector2Int itemGridPosition;
    public string itemModelJson;
}

public enum InventorySlotStatus
{
    Empty,
    Full
}
