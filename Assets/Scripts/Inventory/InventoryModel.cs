using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inventory Model for MVC inventories
/// </summary>
[System.Serializable]
public class InventoryModel
{
    /// <summary>
    /// Data item with all items available in this character
    /// </summary>
    public List<DataItem> invData;

    /// <summary>
    /// Adds an item to this inventory, if it exists it will just add a new instance
    /// </summary>
    /// <param name="item">Item to be added</param>
    public void AddItem(Item item)
    {
        var foundItem = invData.Find(x => x._item.Equals(item));
        if (foundItem == null)
            invData.Add(new DataItem(1, item));
        else
            foundItem.count++;
    }

    /// <summary>
    /// Removes an item from this inventory, if not exists, it will skip
    /// </summary>
    /// <param name="item">Item to be removed</param>
    public void RemoveItem(Item item)
    {
        var foundItem = invData.Find(x => x._item.Equals(item));
        if (foundItem != null)
        {
            foundItem.count--;
            if (foundItem.count <= 0)
                invData.Remove(foundItem);
        }
    }

    /// <summary>
    /// Use the item and removes an instance from the list
    /// </summary>
    /// <param name="item">Item to use</param>
    public void UseItem(Item item)
    {
        var foundItem = invData.Find(x => x._item.Equals(item));
        if (foundItem != null)
        {
            foundItem._item.Use();
            foundItem.count--;
            if (foundItem.count <= 0)
                invData.Remove(foundItem);
        }
    }

    /// <summary>
    /// Ask if this model has the item
    /// </summary>
    /// <param name="item">Item to search</param>
    /// <returns></returns>
    public bool HasItem(Item item)
    {
        var foundItem = invData.Find(x => x._item.Equals(item));
        return foundItem != null;
    }
}

/// <summary>
/// Has the data item and amount of it
/// </summary>
[System.Serializable]
public class DataItem
{
    public int count;
    public Item _item;

    public DataItem(int amount, Item newItem)
    {
        count = amount;
        _item = newItem;
    }
}
