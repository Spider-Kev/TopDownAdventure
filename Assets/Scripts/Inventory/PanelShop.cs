using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Will serve as Controller between model seller and view seller
/// also for player model and player view (just for selling, can't equip) 
/// </summary>
public class PanelShop : MonoBehaviour
{
    /// <summary>
    /// Singleton reference
    /// </summary>
    public static PanelShop instance;
    
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Button to close the view of the shop
    /// </summary>
    public Button btn_Close;
    /// <summary>
    /// Canvas shop containing the seller and player views
    /// </summary>
    public Canvas canvasShop;
    #endregion
    
    #region PUBLIC_REFERENCES
    /// <summary>
    /// Reference to player View of MVC
    /// </summary>
    public InventoryView playerSellInventory;
    /// <summary>
    /// Reference to seller View of MVC
    /// </summary>
    public InventoryView sellerInventory;
    /// <summary>
    /// Selection panel to show when buying or selling items
    /// </summary>
    public PanelItemSelected panelItemsBuy;
    #endregion
    

    #region UNITY_METHODS
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        btn_Close.onClick.AddListener(CloseShop);
        canvasShop.enabled = false;
    }

    /// <summary>
    /// Observer patter listening when a Seller is selected
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("SellerSelected", OnSellerSelected);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SellerSelected", OnSellerSelected);
    }
    #endregion

    #region PUBLIC_METHODS

    /// <summary>
    /// Update the info in the shop by the seller inventory
    /// </summary>
    public void UpdateShopInfo()
    {
        playerSellInventory.FillInventory(InventoryController.instance.invModel.invData);
    }
    #endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// Close the shop view and restores the block
    /// </summary>
    private void CloseShop()
    {
        canvasShop.enabled = false;
        EventManager.TriggerEvent("ShowedPanel", false);
    }
    #endregion
    
    #region LISTENER_METHODS
    /// <summary>
    /// When a seller is selected, it will display its inventory store
    /// </summary>
    /// <param name="arg0">Selected Seller</param>
    private void OnSellerSelected(object arg0)
    {
        canvasShop.enabled = true;
        
        sellerInventory.FillInventory( ((InventoryModel)arg0).invData );
        playerSellInventory.FillInventory(InventoryController.instance.invModel.invData);

        panelItemsBuy.targetToggle.isOn = true;
    }
    #endregion
}
