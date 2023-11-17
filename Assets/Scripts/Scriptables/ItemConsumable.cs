using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that is used just once and it removes a single instance from the Inventory
/// </summary>
[CreateAssetMenu(fileName = "Consumable", menuName = "Scriptables/NewConsumable")]
public class ItemConsumable : Item
{
    #region OVERRIDE_METHODS
    /// <summary>
    /// Implements the use method for the item
    /// </summary>
    public override void Use()
    {
        
    }
    #endregion
    
}
