using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerRewards : MonoBehaviour
{
    /// <summary>
    /// Could be implemented something else other than just coins
    /// </summary>
    public PoolManager poolCoins;

    #region UNITY_METHODS
    /// <summary>
    /// Start and stop listening for a destroyed object in order to spawn in its location
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("DestroyedObject", OnDestroyedObject);
    }

    private void OnDisable()
    {
        EventManager.StartListening("DestroyedObject", OnDestroyedObject);
    }
    #endregion

    #region LISTENER_METHODS
    /// <summary>
    /// Listener method to spawn rewards
    /// </summary>
    /// <param name="arg0">Reference to the destroyed object class</param>
    private void OnDestroyedObject(object arg0)
    {
        poolCoins.AskForObject(((DestroyableObjects)arg0).transform.position);
    }
    #endregion
}
