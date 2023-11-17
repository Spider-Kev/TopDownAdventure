using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Overrides the TextMeshPro updating the currency of the player each time it changes
/// </summary>
public class CurrencyText : TextMeshProUGUI
{
    #region OVERRIDE_UNITY_METHODS
    /// <summary>
    /// Observer pattern
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartListening("CurrencyChanged", OnCurrencyChanged);
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.StopListening("CurrencyChanged", OnCurrencyChanged);
    }
    #endregion

    #region LISTENER_EVENTS
    /// <summary>
    /// Changes this text when the user changes its currency
    /// </summary>
    /// <param name="arg0"></param>
    private void OnCurrencyChanged(object arg0)
    {
        text = PlayerData.money.ToString();
    }
    

    #endregion
    
}
