using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : AppElement
{
    public Vector2 inventorySize;
    public InventorySlotStatus[,] Inventory;
    
    public void Awake()
    {
        Inventory = new InventorySlotStatus[(int)inventorySize.x, (int)inventorySize.y];
    }
}

public enum InventorySlotStatus
{
    Empty,
    Full
}
