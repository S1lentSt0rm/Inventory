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
        
        //test
        
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
            var index = inventoryModel.inventorySize.x * item.itemGridPosition.x + item.itemGridPosition.y;
            
            var itemView = Instantiate(item.itemModel.ItemModelSO.prefab, inventoryContainer.transform.GetChild(index)).GetComponent<ItemView>();
            itemView.itemModel = item.itemModel;
            itemView.isInInventory = true;
        }
        
        
    }

    public void UpdateInventoryView()
    {
        foreach (Transform child in inventoryContainer.transform)
        {
            if (child.childCount > 0)
            {
                Destroy(child.GetChild(0).gameObject);
            }
        }

        // int childCount = inventoryContainer.transform.childCount;
        // for (int i = childCount - 1; i >= 0; i--)
        // {
        //     Destroy(inventoryContainer.transform.GetChild(i).gameObject);
        // }
        //
        
        foreach (Transform child in dropContainer.transform)
        {
            Destroy(child.gameObject);
        }
        
        var inventoryModel = Application.Instance.model.inventoryModel;
        
        foreach (var item in inventoryModel.inventoryItemList)
        {
            var index = inventoryModel.inventorySize.x * item.itemGridPosition.x + item.itemGridPosition.y;
            
            var clone = Instantiate(item.itemModel.ItemModelSO.prefab, inventoryContainer.transform);
            clone.transform.SetParent(inventoryContainer.transform.GetChild(index));
            clone.transform.localPosition = Vector3.zero;
            var itemView = clone.GetComponent<ItemView>();
            itemView.itemModel = item.itemModel;
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
