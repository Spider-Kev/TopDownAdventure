using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to GameOver if the player triggers it
/// </summary>
public class TriggeringObjectGameOver : PickableObject
{
    #region PUBLIC_REFERENCES
    /// <summary>
    /// The player must control this item to finish the game when entering here
    /// </summary>
    public Item itemToControl;
    #endregion
    
    #region OVERRIDE_METHODS

    /// <summary>
    /// Check if the player hast the item in this class to Win the game
    /// </summary>
    public override void PickObject()
    {
        if (InventoryController.instance.invModel.HasItem(itemToControl))
            EventManager.TriggerEvent("GameOver", true);
    }

    #endregion
}
