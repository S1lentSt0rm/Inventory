using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject inventoryContainer;
    [SerializeField] private GameObject dropContainer;
    
    [SerializeField] private GameObject inventoryCellPrefab;

    public void Start()
    {
        var inventoryModel = Application.Instance.model.inventoryModel;
        foreach (var cell in inventoryModel.Inventory)
        {
            Instantiate(inventoryCellPrefab, inventoryContainer.transform);
        }

        foreach (var item in inventoryModel.dropItemList)
        {
            Instantiate(item.ItemModelSO.prefab, dropContainer.transform);
        }
    }

}
