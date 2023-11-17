using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Character or object in the scene that just trigger the DialogueManager
/// </summary>
public class CharacterSpeaker : MonoBehaviour, IInteractable
{
    #region PUBLIC_VARIABLES
/// <summary>
/// Clip that plays when you get the item
/// </summary>
    public AudioClip audioFound;
    /// <summary>
    /// Default dialogue this character will trigger
    /// </summary>
    public Dialogue targetDialogueLines;
    /// <summary>
    /// This dialogue will launch if the player has the item assigned
    /// inside its inventory. Could be null if no needed
    /// </summary>
    public Dialogue dialogueWithItem;
    #endregion

    #region PUBLIC_REFERENCES
    /// <summary>
    /// The item this character is searching to, it could be null if this character
    /// is not searching for an item
    /// </summary>
    public Item searchedItem;
    public Item itemToGive;
    #endregion
    
    
    #region INTERFACE_METHODS
    /// <summary>
    /// Interact event implemented, if it request for an item it will ask if the player
    /// has it, if so it will remove it and offer a gifted item if it's not null
    /// Otherwise it will trigger the default dialogue
    /// </summary>
    public void Interact()
    {
        if (searchedItem != null)
        {
            if (InventoryController.instance.invModel.HasItem(searchedItem))
            {
                EventManager.TriggerEvent("StartDialogue",dialogueWithItem);
                if (itemToGive != null)
                {
                    InventoryController.instance.invModel.AddItem(itemToGive);
                    itemToGive = null;
                    EventManager.TriggerEvent("PlayClipOnce", audioFound);
                }
                InventoryController.instance.invModel.RemoveItem(searchedItem);
                return;
            }
        }
        
        EventManager.TriggerEvent("StartDialogue",targetDialogueLines);
    }
    #endregion
    
}
