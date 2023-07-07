using UnityEngine;

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
            var itemView = Instantiate(item.itemModelSO.prefab, dropContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = false;
            
        }
        foreach (var item in inventoryModel.InventoryItemList)
        {
            var index = inventoryModel.inventorySize.x * item.ItemGridPosition.x + item.ItemGridPosition.y;
            var itemView = Instantiate(item.ItemModel.itemModelSO.prefab, 
                inventoryContainer.transform.GetChild(index)).GetComponent<ItemView>();
            itemView.itemModel = item.ItemModel;
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

        foreach (Transform child in dropContainer.transform)
        {
            Destroy(child.gameObject);
        }
        
        var inventoryModel = Application.Instance.model.inventoryModel;
        
        foreach (var item in inventoryModel.InventoryItemList)
        {
            var index = inventoryModel.inventorySize.x * item.ItemGridPosition.x + item.ItemGridPosition.y;
            var clone = Instantiate(item.ItemModel.itemModelSO.prefab, inventoryContainer.transform);
            clone.transform.SetParent(inventoryContainer.transform.GetChild(index));
            clone.transform.localPosition = Vector3.zero;
            var itemView = clone.GetComponent<ItemView>();
            itemView.itemModel = item.ItemModel;
            itemView.isInInventory = true;
        }
        
        foreach (var item in inventoryModel.dropItemList)
        {
            var itemView = Instantiate(item.itemModelSO.prefab, dropContainer.transform).GetComponent<ItemView>();
            itemView.itemModel = item;
            itemView.isInInventory = false;
        }
        
    }

}
