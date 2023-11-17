using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Interact with other NPC or objects
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Mask to check if has interaction
    /// </summary>
    public LayerMask mask;
    #endregion

    #region PRIVATE_VARIABLES
    [SerializeField] private bool blockInteraction;
    #endregion
    
    #region PRIVATE_REFERENCES
/// <summary>
/// Needs the characterAnimation for orientation of the interaction
/// </summary>
    public AnimationCharacter characterAnimation;
/// <summary>
/// Stores the interactable interface to call its Interact method
/// </summary>
    private IInteractable interactables;
    #endregion

    #region UNITY_METHODS
    private void OnEnable()
    {
        EventManager.StartListening("ShowedPanel", OnShowedPanel);
    }

    private void OnDisable()
    {
        EventManager.StopListening("ShowedPanel", OnShowedPanel);
    }

    /// <summary>
    /// If the user interacts with this object, it will trigger the interact event
    /// </summary>
    private void Update()
    {
        if (blockInteraction)
            return;
        
        if (InputHandler.action)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, characterAnimation.dir, 2f, mask);
            if (hit.collider!=null)
            {
                IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();
                if (interactableObject != null)
                {
                    interactableObject.Interact();
                    EventManager.TriggerEvent("ShowedPanel", true);
                }
                    
            }
        }
    }
    #endregion

    #region LISTENER_METHODS
    private void OnShowedPanel(object arg0)
    {
        blockInteraction = (bool)arg0;
    }
    #endregion
    
    
}
