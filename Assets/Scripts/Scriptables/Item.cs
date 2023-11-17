using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    #region PUBLIC_PROPERTIES
    /// <summary>
    /// Id of this item
    /// </summary>
    public int itemId;
    
    /// <summary>
    /// Item name to be displayed
    /// </summary>
    public string itemName;
    
    /// <summary>
    /// Purchase price of the item, to selling it will be half
    /// </summary>
    public int price;

    /// <summary>
    /// Icon of this item
    /// </summary>
    public Sprite itemIcon;

    /// <summary>
    /// Description of the item
    /// </summary>
    public string description;

    /// <summary>
    /// Audio clip when the item is used
    /// </summary>
    public AudioClip clipUse;
    #endregion

    #region METHODS
    /// <summary>
    /// Function to use this item
    /// </summary>
    public abstract void Use();
    #endregion
    
}