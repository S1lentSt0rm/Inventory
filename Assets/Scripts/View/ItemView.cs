using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GameObject itemVisual;

    public void ItemOnClick()
    {
        Application.Instance.notification.inventoryNotification.DropItemOnClick.Invoke(this);
    }
}
