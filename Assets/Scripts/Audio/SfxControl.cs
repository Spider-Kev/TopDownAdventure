using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// SFX Control for all one shot sounds
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SfxControl : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Require the AudioSource component
    /// </summary>
    public AudioSource source;
    #endregion
    
    #region UNITY_METHODS
    /// <summary>
    /// Listen for an attacking sound, equip and cloth
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("Attacking", OnAttack);
        EventManager.StartListening("EquipWeapon", OnUsedItem);
        EventManager.StartListening("UseCloth", OnUsedItem);
        EventManager.StartListening("PlayClipOnce", PlayAudioOnce);
        
        
    }

    private void OnDisable()
    {
        EventManager.StopListening("Attacking", OnAttack);
        EventManager.StopListening("EquipWeapon", OnUsedItem);
        EventManager.StopListening("UseCloth", OnUsedItem);
        EventManager.StopListening("PlayClipOnce", PlayAudioOnce);
    }
    #endregion

    #region LISTENER_METHODS

    /// <summary>
    /// Only for attack, use the assigned sound in the weapon
    /// </summary>
    /// <param name="arg">ItemWeapon reference of the held weapon</param>
    private void OnAttack(object arg)
    {
        source.PlayOneShot( ((ItemWeapon)arg).audioAttack );
    }
    
    /// <summary>
    /// Plays a sound when any item is used
    /// </summary>
    /// <param name="arg0">Item reference to the item used</param>
    private void OnUsedItem(object arg0)
    {
        source.PlayOneShot(((Item)arg0).clipUse);
    }
    
    
    /// <summary>
    /// Plays a sound when collected coins
    /// </summary>
    /// <param name="arg0"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void PlayAudioOnce(object arg0)
    {
        source.PlayOneShot(((AudioClip)arg0));
    }
    #endregion
}
