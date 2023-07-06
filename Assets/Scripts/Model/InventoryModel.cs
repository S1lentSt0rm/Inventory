using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryModel : MonoBehaviour
{
    public Vector2 inventorySize;
    public InventorySlotStatus[,] Inventory;

    public struct AddItem
    {
        public Vector2Int itemGridPosition;
        public ItemModel itemModel;
    }

    public List<AddItem> inventoryItemList = new List<AddItem>();
    public List<ItemModel> dropItemList = new List<ItemModel>();
    
    
    private void Awake()
    {
        Inventory = new InventorySlotStatus[(int)inventorySize.x, (int)inventorySize.y];
    }
}

public enum InventorySlotStatus
{
    Empty,
    Full
}
