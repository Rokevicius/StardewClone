using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

       AddItem(new Item { itemType = Item.ItemType.Seeds, amount = 20 });
       // AddItem(new Item { itemType = Item.ItemType.Axe, amount = 1 });
       // AddItem(new Item { itemType = Item.ItemType.Pickaxe, amount = 1 });
        //Debug.Log(itemList.Count);
    }

    public void AddItem (Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInvenotry = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInvenotry = true;
                }
            }
            if (!itemAlreadyInInvenotry)
            {
                itemList.Add(item);          
            }
        }
        else itemList.Add(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public bool CheckItem(Item.ItemType type)
    {
        foreach (Item item in GetItemList())
        {
            if (item.itemType == type && item.amount > 0)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(Item.ItemType item)
    {
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item)
            {
                if (inventoryItem.amount > 0)
                {
                    inventoryItem.amount -= 1;
                    break;
                }
            }
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
