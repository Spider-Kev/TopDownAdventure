using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Objects that can be destroyed and leave a Reward
/// </summary>
public class DestroyableObjects : MonoBehaviour, IDamagable, IDropReward
{
    /// <summary>
    /// Interface implementation of health and reward 
    /// </summary>
    public int health { get; set; }
    public int rewardProbability { get; set; }
    
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Starting health of this IDamageable object
    /// </summary>
    public int startingHealt = 10;
    /// <summary>
    /// Probability of leaving a reward
    /// </summary>
    public int probabilityReward = 5;
    #endregion

    #region UNITY_METHODS
    /// <summary>
    /// Assigning the starting values into the interface properties 
    /// </summary>
    private void Start()
    {
        health = startingHealt;
        rewardProbability = probabilityReward;
    }
    #endregion
    
    #region INTERFACE_METHODS
    /// <summary>
    /// Damage dealt to this object
    /// </summary>
    /// <param name="damageDealt">Amount of damage received</param>
    public void Damage(int damageDealt)
    {
        health -= damageDealt;
        if (health<=0)
            DestroyObject();
    }

    /// <summary>
    /// Implementation of destroyed object, if the probability is in range
    /// it will leave a reward.
    /// </summary>
    public void DestroyObject()
    {
        // Remove commit to work with probability reward 
        //if (Random.Range(1,11)<=rewardProbability)
            DropReward();
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Dropping a rewards is launching the listener with this class as instance
    /// </summary>
    public void DropReward()
    {
        EventManager.TriggerEvent("DestroyedObject", this);
    }
    #endregion

    
   
}
