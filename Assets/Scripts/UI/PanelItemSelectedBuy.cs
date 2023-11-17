using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Panel when a player is buying an item
/// </summary>
public class PanelItemSelectedBuy : PanelItemSelected
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Canvas of the selected item info
    /// </summary>
    public Canvas canvasBuy;
    #endregion
    
    #region OVERRIDE_METHODS
    /// <summary>
    /// Confirm the buy of an item and triggers the event
    /// </summary>
    protected override void ConfirmAction()
    {
        EventManager.TriggerEvent("BoughtItem", selectedItem);
        EmptyInfo();
    }

    /// <summary>
    /// Select the item and disables the confirm button if the player has no enough money
    /// </summary>
    protected override void ItemSelected()
    {
        btnConfirm.interactable = selectedItem.price <= PlayerData.money;
    }

    /// <summary>
    /// When the toggle value changes it will display or hide the inventory info
    /// </summary>
    /// <param name="arg0"></param>
    protected override void OnToggleValueChanged(bool arg0)
    {
        bool value = (bool)arg0;
        canvasBuy.enabled = value;
        canvasInfo.enabled = value;
        PanelShop.instance.UpdateShopInfo();
        EmptyInfo();
    }

    #endregion
}
