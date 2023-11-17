using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Item to equip as a weapon and attack could be melee or ranged
/// </summary>
public class ItemWeapon : Item
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Damage this weapon would deal
    /// </summary>
    public int damageAmount;
    
    /// <summary>
    /// Audio to play when this item attacks
    /// </summary>
    public AudioClip audioAttack;
    #endregion

    #region ITEM_METHODS
    /// <summary>
    /// Implement Use of Item class 
    /// </summary>
    public override void Use()
    {
        EventManager.TriggerEvent("EquipWeapon", this);
    }
    #endregion
    
}
