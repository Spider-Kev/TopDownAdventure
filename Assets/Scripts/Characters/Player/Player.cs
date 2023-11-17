using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Player class, handle the basic behaviour of moving
/// </summary>
public class Player : Character
{
    #region PRIVATE_VARIABLES
    /// <summary>
    /// Variable to stop the player interaction
    /// </summary>
    private bool blockPlayer;
    #endregion
    
    #region UNITY_METHODS
    /// <summary>
    /// Starts the default values in the PlayerData
    /// </summary>
    private void Start()
    {
        PlayerData.SetStats(200,100);
    }

    /// <summary>
    /// Listens when ShowedPanel triggers to block the player interaction
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("ShowedPanel", OnShowedPanel);
    }

    private void OnDisable()
    {
        EventManager.StopListening("ShowedPanel", OnShowedPanel);
    }
    
    /// <summary>
    /// Move the player and update it AnimationCharacter component with the Axis values 
    /// </summary>
    private void Update()
    {
        if (blockPlayer)
            return;
        
        Vector3 movement = new Vector3(InputHandler.horizontal, InputHandler.vertical, 0f );
        transform.Translate(movement * speed * Time.deltaTime);

        if (animationCharacter != null)
            animationCharacter.SetAnimation(movement);
    }
    #endregion

    #region LISTENER_METHODS
    /// <summary>
    /// Called when triggered the ShowedPanel message from Observer pattern
    /// </summary>
    /// <param name="arg0">Bool if the Player will be blocked</param>
    private void OnShowedPanel(object arg0)
    {
        blockPlayer = (bool)arg0;
    }
    #endregion
}
