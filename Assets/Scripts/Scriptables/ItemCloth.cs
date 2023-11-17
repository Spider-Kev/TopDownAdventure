using UnityEngine;

/// <summary>
/// Item type of cloth that can be equipped and assigned into sprite Renderers into the player
/// </summary>
[CreateAssetMenu(fileName = "Cloth", menuName = "Scriptables/NewCloth")]
public class ItemCloth : Item
{
    #region PUBLIC_VARIABLES
    public Sprite armL;
    public Sprite armR;
    public Sprite finger;
    public Sprite foreArmL;
    public Sprite foreArmR;
    public Sprite handL;
    public Sprite handR;
    public Sprite leg;
    public Sprite pelvis;
    public Sprite shin;
    public Sprite sleeveR;
    public Sprite torso;
    #endregion
    
    #region OVERRIDE_METHODS
    /// <summary>
    /// Implements the use method for the item
    /// </summary>
    public override void Use()
    {
        EventManager.TriggerEvent("UseCloth", this);
    }
    #endregion
    
}
