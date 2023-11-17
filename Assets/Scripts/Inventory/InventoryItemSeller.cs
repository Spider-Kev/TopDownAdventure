using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Inventory cell of the Seller to be displayed in the View of the seller MVC 
/// </summary>
public class InventoryItemSeller : InventoryItem
{
    /// <summary>
    /// Price it will display
    /// </summary>
    public TextMeshProUGUI textPrice;
    /// <summary>
    /// Name of this item
    /// </summary>
    public TextMeshProUGUI textName;
    #region OVERRIDE_METHODS
    public override void ClickElement()
    {
        InteractItem();
    }
    #endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// When selected, triggers the SelectedItem message to display the complete info
    /// </summary>
    private void InteractItem()
    {
        EventManager.TriggerEvent("SelectedItem", itemRef);
    }
    #endregion

    #region OVERRIDE_METHODS
    /// <summary>
    /// Sets the info of the store
    /// </summary>
    public override void SetInfo()
    {
        textPrice.text = itemRef.price.ToString();
        textName.text = itemRef.itemName;
        //textCount.text = itemRef.amount.ToString();
    }

    /// <summary>
    /// Empty the info of this cell
    /// </summary>
    public override void RemoveInfo()
    {
        textPrice.text = string.Empty;
        textName.text = string.Empty;
        textCount.text = string.Empty;
    }
    #endregion
}
