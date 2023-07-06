using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        // Application.Instance.view.inventoryView.Init();
        
        Application.Instance.notification.inventoryNotification.ItemOnClick.AddListener(TryToMoveItem);
    }

    private static void TryToMoveItem(ItemView item)
    {
        if (item.isInInventory)
        {
            Application.Instance.model.inventoryModel.inventoryItemList.Remove(item.itemModel);
            Application.Instance.model.inventoryModel.dropItemList.Add(item.itemModel);
        }
        else
        {
            Application.Instance.model.inventoryModel.dropItemList.Remove(item.itemModel);
            Application.Instance.model.inventoryModel.inventoryItemList.Add(item.itemModel);
        }

        Application.Instance.view.inventoryView.UpdateInventoryView();
        
        //Application.Instance.model.inventoryModel.inventoryItemList.Add(new InventoryModel.AddItem(new Vector2Int(1,1)));
        // Debug.Log(item.name);
        // Destroy(item.gameObject);
    }
}
