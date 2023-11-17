using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player "Controller" of MVC pattern in the inventory
/// </summary>
public class InventoryController : MonoBehaviour
{
    /// <summary>
    /// Singleton pattern
    /// </summary>
    public static InventoryController instance;

    #region PUBLIC_VARIABLES
    /// <summary>
    /// Button to show the View of the inventory
    /// </summary>
    public Button btn_ShowInventory;
    /// <summary>
    /// Button to hide the View of the inventory
    /// </summary>
    public Button btn_CloseInventory;
    /// <summary>
    /// Canvas of the view
    /// </summary>
    public Canvas canvasInventory;
    #endregion
    
    #region PUBLIC_REFERENCES
    /// <summary>
    /// Reference to "Model" of the MVC player inventory
    /// </summary>
    public InventoryModel invModel;
    /// <summary>
    /// Reference to "View" of the MVC player inventory
    /// </summary>
    public InventoryView invView;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Assign the show and hide behaviors of both buttons
    /// </summary>
    private void Start()
    {
        if (btn_ShowInventory!=null)
            btn_ShowInventory.onClick.AddListener(ShowInventory);
        if (btn_CloseInventory)
            btn_CloseInventory.onClick.AddListener(HideInventory);
    }

    /// <summary>
    /// Observer pattern to bought and sold to update this view
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("BoughtItem", OnItemBought);
        EventManager.StartListening("SoldItem", OnSoldItem);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BoughtItem", OnItemBought);
        EventManager.StopListening("SoldItem", OnSoldItem);

    }
    #endregion

    #region PUBLIC_METHODS
    /// <summary>
    /// Shows the View of the MVC inventory
    /// </summary>
    public void ShowInventory()
    {
        invView.FillInventory(invModel.invData);
        canvasInventory.enabled = true;
        EventManager.TriggerEvent("ShowedPanel", true);
    }
    
    /// <summary>
    /// Hides the View of the MVC inventory
    /// </summary>
    public void HideInventory()
    {
        canvasInventory.enabled = false;
        EventManager.TriggerEvent("ShowedPanel", false);
    }
    #endregion

    #region LISTENER_METHODS
    /// <summary>
    /// When an item is bought it should be added to the model and update the view
    /// </summary>
    /// <param name="arg0">Item bought</param>
    private void OnItemBought(object arg0)
    {
        Item boughtItem = (Item)arg0;
        invModel.AddItem(boughtItem);
        ShowInventory();
        PlayerData.ChangeCurrency(-boughtItem.price);
    }

    /// <summary>
    /// When an item is sold it should be removed from the model and update the view
    /// </summary>
    /// <param name="arg0">Sold item</param>
    private void OnSoldItem(object arg0)
    {
        Item soldItem = (Item)arg0;
        invModel.RemoveItem(soldItem);
        ShowInventory();
        PlayerData.ChangeCurrency(soldItem.price / 2);
    }
    #endregion
}
