using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Type of character that is interactable and has an Inventory for selling
/// </summary>
public class CharacterSeller : Character, IInteractable
{
    #region PUBLIC_REFERENCES
    /// <summary>
    /// This will serve as a model for a MVC to the Shop
    /// </summary>
    public InventoryModel inventorySell;
    #endregion
    
    
    #region INTERFACE_METHODS
    /// <summary>
    /// Interface implementation of the Interact interface
    /// </summary>
    public void Interact()
    {
        EventManager.TriggerEvent("SellerSelected", inventorySell);
    }
    #endregion

    
}
