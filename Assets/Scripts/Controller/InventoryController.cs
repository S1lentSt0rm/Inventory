using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        // Application.Instance.view.inventoryView.Init();
        
        Application.Instance.notification.inventoryNotification.DropItemOnClick.AddListener(TryMoveItemToInventory);
    }

    private static void TryMoveItemToInventory(ItemView item)
    {
        Debug.Log(item.name);
        Destroy(item.gameObject);
    }
}
