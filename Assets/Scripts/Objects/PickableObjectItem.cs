using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Item to be picked when a player pass on it
/// </summary>
public class PickableObjectItem : PickableObject
{
    #region PUBLIC_REFERENCES
/// <summary>
/// If not null it will be the audio this item will play when collected
/// </summary>
    public AudioClip clipCollected;
    
    /// <summary>
    /// Item to be added to player
    /// </summary>
    public Item itemToPick;
    #endregion
    
    #region OVERRIDE_METHODS
    /// <summary>
    /// When the player pass through the player, it will add the item to its inventary
    /// </summary>
    public override void PickObject()
    {
        InventoryController.instance.invModel.AddItem(itemToPick);
        if (clipCollected!=null)
            EventManager.TriggerEvent("PlayClipOnce", clipCollected);
        gameObject.SetActive(false);
    }

    #endregion
}
