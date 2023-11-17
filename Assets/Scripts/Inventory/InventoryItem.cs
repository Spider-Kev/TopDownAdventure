using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Prefab of an item when showed in the store
/// </summary>
public class InventoryItem : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Amount of this object in the inventory
    /// </summary>
    public TextMeshProUGUI textCount;
    /// <summary>
    /// Reference to the item held by this instance 
    /// </summary>
    public Item itemRef;
    /// <summary>
    /// Image reference to show the icon 
    /// </summary>
    public Image image;
    /// <summary>
    /// Button when pressed this item
    /// </summary>
    public Button btnItem;
    #endregion


    #region UNITY_METHODS
    private void Start()
    {
        btnItem.onClick.AddListener(()=> ClickElement());
    }
    #endregion

    #region PUBLIC_METHODS
    /// <summary>
    /// When access it will fill the data with the Item
    /// </summary>
    /// <param name="item">Item info</param>
    /// <param name="count"></param>
    public void AssignItem(Item item, int count)
    {
        itemRef = item;
        image.sprite = item.itemIcon;
        image.color = Color.white;
        btnItem.interactable = true;
        textCount.text = count.ToString();
        SetInfo();
    }

    /// <summary>
    /// Fills empty when there's no item
    /// </summary>
    public void UnassignItem()
    {
        itemRef = null;
        image.color = Color.clear;
        btnItem.interactable = false;
        RemoveInfo();
    }
    #endregion


    #region VIRTUAL_METHODS
    public virtual void SetInfo()
    {
        
    }

    public virtual void RemoveInfo()
    {
        
    }
    
    public virtual void ClickElement()
    {
        itemRef.Use();
    }
    #endregion

}
