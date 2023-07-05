using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : AppElement
{
    private void Start()
    {
        application.view.InventoryView.Init();
    }
}
