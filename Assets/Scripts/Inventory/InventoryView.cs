using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// View of the MVC inventary systems
/// </summary>
public class InventoryView : MonoBehaviour
{
    #region PUBLIC_REFERENCES
    /// <summary>
    /// Max items of the element to be displayed by the ui
    /// </summary>
    public InventoryItem[] inventorySingles;
    #endregion
    
    #region PUBLIC_METHODS
    /// <summary>
    /// Fills the inventory inside the count cells of this view
    /// </summary>
    /// <param name="items"></param>
    public void FillInventory(List<DataItem> items)
    {
        for (int i = 0; i < inventorySingles.Length; i++)
        {
            if (i >= items.Count)
                RemoveItemToView(i);
            else
                AddItemToView(items[i], i);
        } 
    }
    #endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// Add a new item to the view in a new cell
    /// </summary>
    /// <param name="_dataItem">Data info</param>
    /// <param name="index">Amount of item</param>
    private void AddItemToView(DataItem _dataItem, int index)
    {
        inventorySingles[index].AssignItem(_dataItem._item, _dataItem.count);
    }

    /// <summary>
    /// Remove an item in a cell index value
    /// </summary>
    /// <param name="index"></param>
    private void RemoveItemToView(int index)
    {
        inventorySingles[index].UnassignItem();
    }

    /// <summary>
    /// Search for all InventoryItem cells in this view, for performance execute this
    /// function in the editor inspector tab
    /// </summary>
    [ContextMenu("Assign items in this parent")]
    private void AssignSingleinventoryItems()
    {
        inventorySingles = GetComponentsInChildren<InventoryItem>();
    }
    #endregion
}
