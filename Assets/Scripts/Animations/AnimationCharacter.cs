using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Handle the Animator component of the assigned Character
/// </summary>
public class AnimationCharacter : MonoBehaviour
{

    #region PUBLIC_VARIABLES
    /// <summary>
    /// Animator of this player
    /// </summary>
    public Animator animator;
    
    /// <summary>
    /// Dir from the Input Handler
    /// </summary>
    public Vector2 dir { get; private set; }
    #endregion

    #region PRIVATE_VARIABLES
    /// <summary>
    /// The local scale to check if the player is facing right or left
    /// </summary>
    private Vector3 localScale;
    #endregion

    #region UNITY_METHODS
    /// <summary>
    /// Start the scale value 
    /// </summary>
    private void Start()
    {
        localScale = transform.localScale;
    }
    #endregion
    
    #region PUBLIC_METHODS
    /// <summary>
    /// Set "speed" param animation in the Animator
    /// </summary>
    /// <param name="direction">Set the direction from the Input</param>
    public void SetAnimation(Vector2 direction)
    {
        animator.SetFloat("speed", direction.magnitude);
        if (direction.magnitude > 0)
        {
            dir = direction;
            if (dir.x != 0)
            {
                localScale.x = dir.x > 0 ? 1 : -1;
                transform.localScale = localScale;
            }
        }
    }

    /// <summary>
    /// Set the attack value of the param in the animator
    /// </summary>
    /// <param name="attackType"></param>
    public void SetAttack(string attackType)
    {
        animator.ResetTrigger(attackType);  // ?
        animator.SetTrigger(attackType);
    }
    #endregion
    
}
