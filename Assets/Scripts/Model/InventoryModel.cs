using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    
    //public List<ItemModel> inventoryItemList = new List<ItemModel>();
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
        Inventory = new InventorySlotStatus[inventorySize.x, inventorySize.y];
    }
}

public enum InventorySlotStatus
{
    Empty,
    Full
}
