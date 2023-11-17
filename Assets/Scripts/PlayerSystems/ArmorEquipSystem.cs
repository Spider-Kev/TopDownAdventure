using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// System that equips the clothes
/// </summary>
public class ArmorEquipSystem : MonoBehaviour
{
    #region PUBLIC_METHODS
    /// <summary>
    /// Reference to all spriteRenderers in the player
    /// </summary>
    public SpriteRenderer sr_armL;
    public SpriteRenderer sr_armR;
    public SpriteRenderer sr_finger;
    public SpriteRenderer sr_foreArmL;
    public SpriteRenderer sr_foreArmR;
    public SpriteRenderer sr_handL;
    public SpriteRenderer sr_handR;
    public SpriteRenderer[] sr_legs;
    public SpriteRenderer sr_pelvis;
    public SpriteRenderer[] sr_shins;
    public SpriteRenderer sr_sleeveR;
    public SpriteRenderer sr_sleeveL;
    public SpriteRenderer sr_torso;
    #endregion
    
    #region UNITY_METHODS
    /// <summary>
    /// Observer waiting for UseCloth message
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("UseCloth", OnUseCloth);
    }

    private void OnDisable()
    {
        EventManager.StopListening("UseCloth", OnUseCloth);
    }
    #endregion

    #region MyRegion
    /// <summary>
    /// When the message is called, it will change the sprite of the spriteRenderers
    /// </summary>
    /// <param name="arg0"></param>
    private void OnUseCloth(object arg0)
    {
        ItemCloth cloth = (ItemCloth)arg0;
        sr_armL.sprite = cloth.armL;
        sr_armR.sprite = cloth.armR;
        sr_finger.sprite = cloth.finger;
        sr_foreArmL.sprite = cloth.foreArmL;
        sr_foreArmR.sprite = cloth.foreArmR;
        sr_handL.sprite = cloth.handL;
        sr_handR.sprite = cloth.handR;
        sr_legs[0].sprite = cloth.leg;
        sr_legs[1].sprite = cloth.leg;
        sr_pelvis.sprite = cloth.pelvis;
        sr_shins[0].sprite = cloth.shin;
        sr_shins[1].sprite = cloth.shin;
        sr_sleeveR.sprite = cloth.sleeveR;
        sr_torso.sprite = cloth.torso;
    }
    #endregion
}
