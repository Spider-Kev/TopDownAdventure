using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coin to picked to increase player currency
/// </summary>
public class PickableObjectCoin : PickableObject
{
    #region PUBLIC_VARIABLES
/// <summary>
/// Clip sounds when collecting coins
/// </summary>
    public AudioClip soundCoins;
    /// <summary>
    /// Coins to be added to player currency
    /// </summary>
    public int coinsAmount = 100;
    #endregion
    
    #region OVERRIDE_METHODS
    /// <summary>
    /// When the player passes, it will update its currency 
    /// </summary>
    public override void PickObject()
    {
        PlayerData.ChangeCurrency(coinsAmount);
        EventManager.TriggerEvent("PlayClipOnce", soundCoins);
        gameObject.SetActive(false);
    }

    #endregion
}
