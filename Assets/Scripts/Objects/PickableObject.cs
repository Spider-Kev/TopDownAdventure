using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable
{
    #region UNITY_METHODS
    /// <summary>
    /// Triggers when collided with player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        PickObject();
    }

    #endregion

    #region INTERFACE_METHODS
    /// <summary>
    /// Virtual method that pickable objects can Implement
    /// </summary>
    public virtual void PickObject()
    {
        
    }
    #endregion
    
}
