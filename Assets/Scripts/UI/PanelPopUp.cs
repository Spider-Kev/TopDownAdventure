using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPopUp : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Canvas canvasPanel;
    public Button btnClose;
    #endregion
    
    #region UNITY_METHODS
    private void Start()
    {
        btnClose.onClick.AddListener(OnHidePopUp);
        AddButtonListener();
    }
    #endregion

    #region LISTENER_METHODS

    private void OnShowPopUp()
    {
        canvasPanel.enabled = true;
    }

    void OnHidePopUp()
    {
        canvasPanel.enabled = false;
    }
    #endregion

    #region VIRTUAL_METHODS
    protected virtual void AddButtonListener()
    {
        
    }
    #endregion
}




