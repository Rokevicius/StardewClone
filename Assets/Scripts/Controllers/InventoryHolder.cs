using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public static InventoryHolder Instance { get; private set; }
    [SerializeField] UIInventory uiInventory;
    public Inventory inventory;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }      
}

