using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GameObject itemVisual;
    public ItemModel itemModel;

    public bool isInInventory = false;//test

    public void ItemOnClick()
    {
        Application.Instance.notification.inventoryNotification.ItemOnClick.Invoke(this);
    }
}
