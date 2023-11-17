using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sword
/// </summary>
[CreateAssetMenu(fileName = "Consumable", menuName = "Scriptables/NewWeaponMelee")]
public class ItemWeaponMelee : ItemWeapon
{
    /// <summary>
    /// Damage range of this weapon, inside it will be consider as hit
    /// </summary>
    public float damageRange;
}
