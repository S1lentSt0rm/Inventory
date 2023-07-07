using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class InventoryTesting : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private List<ItemModelSO> possibleItems;

    [SerializeField] private int dropItemCount;

    private void Awake()
    {
        if (File.Exists("inventoryData.json"))
        {
            return;
        }
        
        for (int i = 0; i < dropItemCount; i++)
        {
            var index = Random.Range(0, possibleItems.Count);
            inventoryModel.dropItemList.Add(new ItemModel(possibleItems[index]));
        }
    }

    private void Update()
    {
        Debug.Log("Inventory item count: "+inventoryModel.InventoryItemList.Count);
        Debug.Log("Drop item count: "+inventoryModel.dropItemList.Count);
    }
}
