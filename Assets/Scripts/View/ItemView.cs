using UnityEngine;

public class ItemView : MonoBehaviour
{
    public ItemModel itemModel;
    public bool isInInventory;

    public void ItemOnClick()
    {
        Application.Instance.notification.inventoryNotification.ItemOnClick.Invoke(this);
    }
}
