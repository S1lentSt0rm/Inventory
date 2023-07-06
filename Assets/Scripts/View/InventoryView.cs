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
        //test
        var inventoryModel = Application.Instance.model.inventoryModel;
        foreach (var item in inventoryModel.dropItemList)
        {
            var itemView = Instantiate(item.ItemModelSO.prefab, dropContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = false;

        }
        foreach (var item in inventoryModel.inventoryItemList)
        {
            // var itemView = Instantiate(item.ItemModelSO.prefab, inventoryContainer.transform);
            // itemView.GetComponent<ItemView>().itemModel = item;
            var itemView = Instantiate(item.ItemModelSO.prefab, inventoryContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = true;
        }
        
        // foreach (var cell in inventoryModel.Inventory)
        // {
        //     Instantiate(inventoryCellPrefab, inventoryContainer.transform);
        // }
    }

    public void UpdateInventoryView()
    {
        foreach (Transform child in inventoryContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in dropContainer.transform)
        {
            Destroy(child.gameObject);
        }
        
        var inventoryModel = Application.Instance.model.inventoryModel;
        foreach (var item in inventoryModel.inventoryItemList)
        {
            var itemView = Instantiate(item.ItemModelSO.prefab, inventoryContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = true;
        }
        foreach (var item in inventoryModel.dropItemList)
        {
            var itemView = Instantiate(item.ItemModelSO.prefab, dropContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = false;
        }
        
    }

}
