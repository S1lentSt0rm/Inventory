using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryView : AppElement
{
    [SerializeField] private GameObject inventoryContainer;
    [SerializeField] private GameObject dropContainer;
    
    [SerializeField] private GameObject inventoryCellPrefab;

    public void Init()
    {
        foreach (var cell in application.model.inventoryModel.Inventory)
        {
            Instantiate(inventoryCellPrefab, inventoryContainer.transform);
        }
    }
}
