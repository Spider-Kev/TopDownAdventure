using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack system of any character
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Need to know which objects it will attack
    /// </summary>
    public LayerMask mask;
    /// <summary>
    /// Change the spriteRenderer of the weapon
    /// </summary>
    public SpriteRenderer sr_weapon;
    #endregion

    #region PUBLIC_REFERENCES
    /// <summary>
    /// Weapon assigned
    /// </summary>
    public ItemWeapon assignedWeapon;
    /// <summary>
    /// Need the CharacterAnimation orientation to know in which direction to attack
    /// </summary>
    public AnimationCharacter characterAnimation;
    #endregion

    #region PRIVATE_VARIABLES
    /// <summary>
    /// Will block any interactions when called the ShowedPanel message
    /// </summary>
    private bool blockInteraction;
    #endregion
    

    #region UNITY_METHODS
    /// <summary>
    /// Observer pattern waiting for Equip and Showed panel messages
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("EquipWeapon", OnEquipWeapon);
        EventManager.StartListening("ShowedPanel", OnShowedPanel);

    }

    private void OnDisable()
    {
        EventManager.StopListening("EquipWeapon", OnEquipWeapon);
        EventManager.StopListening("ShowedPanel", OnShowedPanel);
    }

    /// <summary>
    /// If no weapon is assigned it will skip the attack
    /// </summary>
    private void Update()
    {
        if (blockInteraction)
            return;
        
        if (assignedWeapon==null)
            return;
        
        if (InputHandler.attack)
        {
            Attack();
        }
    }

    #endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// Performs the attack of the weapon assigned
    /// </summary>
    private void Attack()
    {
        if (assignedWeapon is ItemWeaponMelee)
        {
            characterAnimation.SetAttack("melee");
            EventManager.TriggerEvent("Attacking", assignedWeapon);
            ItemWeaponMelee weapon = (ItemWeaponMelee)assignedWeapon; 

            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1,Vector2.zero, 0, mask);
            if (hit.collider!=null)
            {
                IDamagable damageableObject = hit.collider.GetComponent<IDamagable>();
                if (damageableObject != null)
                {
                    damageableObject.Damage(weapon.damageAmount);
                    
                }
            }
        }
        
    }
    #endregion

    #region LISTENER_METHODS
/// <summary>
/// Equip the weapon assigned
/// </summary>
/// <param name="arg">Weapon assigned</param>
    private void OnEquipWeapon(object arg)
    {
        assignedWeapon = (ItemWeapon)arg;
        if (assignedWeapon != null)
            sr_weapon.sprite = assignedWeapon.itemIcon;
    }
    
/// <summary>
/// Blocks the user to not attack until the panel hides
/// </summary>
/// <param name="arg0"></param>
    private void OnShowedPanel(object arg0)
    {
        blockInteraction = (bool)arg0;
    }
    #endregion
}
