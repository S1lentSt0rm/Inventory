using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InventoryNotification : MonoBehaviour
{
    public UnityEvent<ItemView> ItemOnClick;
}
