using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class InventoryModel : MonoBehaviour
{
    public Vector2Int inventorySize;
    public InventorySlotStatus[,] Inventory;

     public struct PlacedItem
     {
         public Vector2Int itemGridPosition;
         public ItemModel itemModel;
    
         public PlacedItem(Vector2Int position, ItemModel itemModel)
         {
             itemGridPosition = position;
             this.itemModel = itemModel;
         }
     }
    public List<PlacedItem> inventoryItemList = new List<PlacedItem>();
    
    public List<ItemModel> dropItemList = new List<ItemModel>();


    public void AddItemToInventory(Vector2Int slot, ItemModel itemModel)
    {
        //inventoryItemList.Add(itemModel);

        //Application.Instance.view.inventoryView.UpdateInventoryView();
    }
    
    public void AddItemToDrop(ItemModel itemModel)
    {
        dropItemList.Add(itemModel);
        //Application.Instance.view.inventoryView.UpdateInventoryView();
    }
    
    private void Awake()
    {
        LoadInventoryData();
        Inventory = new InventorySlotStatus[inventorySize.x, inventorySize.y];
        foreach (var item in inventoryItemList)
        {
            Inventory[item.itemGridPosition.x, item.itemGridPosition.y] = InventorySlotStatus.Full;
        }
    }

    public void SaveInventoryData()
    {
        InventoryData inventoryData = new InventoryData();
        inventoryData.inventorySize = inventorySize;

        List<PlacedItemData> serializedInventoryItems = new List<PlacedItemData>();
        foreach (var placedItem in inventoryItemList)
        {
            PlacedItemData placedItemData = new PlacedItemData();
            placedItemData.itemGridPosition = placedItem.itemGridPosition;
            placedItemData.itemModelJson = placedItem.itemModel.Serialize();
            serializedInventoryItems.Add(placedItemData);
        }
        inventoryData.inventoryItemList = serializedInventoryItems.ToArray();
        
        List<string> serializedDropItems = new List<string>();
        foreach (var dropItem in dropItemList)
        {
            serializedDropItems.Add(dropItem.Serialize());
        }
        inventoryData.dropItemList = new List<string>(serializedDropItems);

        string json = JsonUtility.ToJson(inventoryData);
        File.WriteAllText("inventoryData.json", json);
    }
    
    public void LoadInventoryData()
    {
        if (!File.Exists("inventoryData.json"))
        {
            return;
        }
        string json = File.ReadAllText("inventoryData.json");
        InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
        
        inventorySize = inventoryData.inventorySize;

        inventoryItemList.Clear();
        foreach (var placedItemData in inventoryData.inventoryItemList)
        {
            PlacedItem placedItem = new PlacedItem();
            placedItem.itemGridPosition = placedItemData.itemGridPosition;
            placedItem.itemModel = ItemModel.Deserialize(placedItemData.itemModelJson);
            inventoryItemList.Add(placedItem);
        }
        
        dropItemList.Clear();
        foreach (var serializedDropItem in inventoryData.dropItemList)
        {
            ItemModel dropItem = ItemModel.Deserialize(serializedDropItem);
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
