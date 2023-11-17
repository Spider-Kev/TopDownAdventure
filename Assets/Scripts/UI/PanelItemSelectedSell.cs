using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Panel when the user sells items
/// </summary>
public class PanelItemSelectedSell : PanelItemSelected
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Canvas with the item info selling
    /// </summary>
    public Canvas canvasSell;
    #endregion
    
    #region OVERRIDE_METHODS
    /// <summary>
    /// The confirm action will sold the selected item, updates the inventory player and triggers
    /// the sell
    /// </summary>
    protected override void ConfirmAction()
    {
        EventManager.TriggerEvent("SoldItem", selectedItem);
        PanelShop.instance.UpdateShopInfo();
        EmptyInfo();
    }
    /// <summary>
    /// Update the info selected from the player inventory and divides half the price
    /// </summary>
    protected override void ItemSelected()
    {
        btnConfirm.interactable = true;
        txt_Cost.text = (selectedItem.price/2).ToString();

    }

    /// <summary>
    /// Show or hide the inventory according to the toggle
    /// </summary>
    /// <param name="arg0"></param>
    protected override void OnToggleValueChanged(bool arg0)
    {
        bool value = (bool)arg0;
        canvasSell.enabled = value;
        canvasInfo.enabled = value;
        EmptyInfo();
    }

    #endregion
}
