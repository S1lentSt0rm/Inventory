using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        // Application.Instance.view.inventoryView.Init();
        
        Application.Instance.notification.inventoryNotification.ItemOnClick.AddListener(TryToMoveItem);
    }

    private static void TryToMoveItem(ItemView itemView)
    {
        var inventoryModel = Application.Instance.model.inventoryModel;
        
        if (itemView.isInInventory)
        {
            InventoryModel.PlacedItem placedItem =
                inventoryModel.inventoryItemList.Find(item => item.itemModel == itemView.itemModel);
            inventoryModel.Inventory[placedItem.itemGridPosition.x, placedItem.itemGridPosition.y] =
                InventorySlotStatus.Empty;
            inventoryModel.inventoryItemList.Remove(placedItem);
            
            inventoryModel.dropItemList.Add(itemView.itemModel);
            Application.Instance.view.inventoryView.UpdateInventoryView();
            
            return;
        }
        
        
        for (int i = 0; i < inventoryModel.inventorySize.x; i++)
        {
            for (int j = 0; j < inventoryModel.inventorySize.y; j++)
            {
                if (inventoryModel.Inventory[i,j] == InventorySlotStatus.Empty)
                {
                    inventoryModel.dropItemList.Remove(itemView.itemModel);
                    inventoryModel.inventoryItemList.Add(new InventoryModel.PlacedItem(new Vector2Int(i,j),itemView.itemModel));
                    inventoryModel.Inventory[i, j] = InventorySlotStatus.Full;
                    Application.Instance.view.inventoryView.UpdateInventoryView();
                    return;
                }
            }
        }
 
        Debug.Log("Cannot place item");
        

        
        
        //Application.Instance.model.inventoryModel.inventoryItemList.Add(new InventoryModel.AddItem(new Vector2Int(1,1)));
        // Debug.Log(item.name);
        // Destroy(item.gameObject);
    }
}
