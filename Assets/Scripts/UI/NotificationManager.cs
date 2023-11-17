using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    #region PUBLIC_REFERENCES
    [SerializeField] private PanelPopUp[] popUps; 
    #endregion
    
    #region UNITY_METHODS
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    #endregion

    #region PRIVATE_METHODS
    [ContextMenu("Search all PopUps")]
    private void AssignAllPopUps()
    {
        popUps = GameObject.FindObjectsOfType<PanelPopUp>();
    }
    #endregion
}
