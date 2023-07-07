using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        Application.Instance.notification.inventoryNotification.ItemOnClick.AddListener(TryToMoveItem);
    }

    private static void TryToMoveItem(ItemView itemView)
    {
        var inventoryModel = Application.Instance.model.inventoryModel;
        
        if (itemView.isInInventory)
        {
            var placedItem =
                inventoryModel.InventoryItemList.Find(item => item.ItemModel == itemView.itemModel);
            inventoryModel.Inventory[placedItem.ItemGridPosition.x, placedItem.ItemGridPosition.y] =
                InventorySlotStatus.Empty;
            inventoryModel.InventoryItemList.Remove(placedItem);
            
            inventoryModel.dropItemList.Add(itemView.itemModel);
            
            Application.Instance.view.inventoryView.UpdateInventoryView();
            Application.Instance.model.inventoryModel.SaveInventoryData();
            
            return;
        }
        else
        {
            for (int i = 0; i < inventoryModel.inventorySize.x; i++)
            {
                for (int j = 0; j < inventoryModel.inventorySize.y; j++)
                {
                    if (inventoryModel.Inventory[i,j] == InventorySlotStatus.Empty)
                    {
                        inventoryModel.dropItemList.Remove(itemView.itemModel);
                        inventoryModel.InventoryItemList.Add(
                            new InventoryModel.PlacedItem(new Vector2Int(i,j),itemView.itemModel));
                        inventoryModel.Inventory[i, j] = InventorySlotStatus.Full;
                        
                        Application.Instance.view.inventoryView.UpdateInventoryView();
                        Application.Instance.model.inventoryModel.SaveInventoryData();
                        
                        return;
                    }
                }
            }
        }
        
        Debug.Log("Cannot place item");
    }
}
