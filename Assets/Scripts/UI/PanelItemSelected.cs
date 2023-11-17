using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Panel that will show the info of the selected item
/// </summary>
public class PanelItemSelected : MonoBehaviour
{
    private const string emptyValue = "---";
    
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Name of the item
    /// </summary>
    public TextMeshProUGUI txt_Name;
    /// <summary>
    /// Cost of the item
    /// </summary>
    public TextMeshProUGUI txt_Cost;
    /// <summary>
    /// Description text of the item
    /// </summary>
    public TextMeshProUGUI txt_Description;
    /// <summary>
    /// Icon of the item
    /// </summary>
    public Image spriteItem;
    /// <summary>
    /// Button to confirm interaction
    /// </summary>
    public Button btnConfirm;
    /// <summary>
    /// Toggle to check if player or seller info is displayed
    /// </summary>
    [Header("Inherited properties")] 
    public Toggle targetToggle;
    /// <summary>
    /// Canvas info of this object
    /// </summary>
    public Canvas canvasInfo;
    #endregion

    #region PRIVATE_REFERENCES
    /// <summary>
    /// Reference to the selected item
    /// </summary>
    public Item selectedItem;
    #endregion
    
    #region UNITY_METHODS
    private void Start()
    {
        btnConfirm.onClick.AddListener(ConfirmAction);
    }

    private void OnEnable()
    {
        StartListenEvents();
        EventManager.StartListening("SelectedItem", OnSelectedItem);
        EventManager.StartListening("SellerSelected", OnSelectedSeller);
        targetToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
    
    private void OnDisable()
    {
        StopListenEvents();
        EventManager.StopListening("SelectedItem", OnSelectedItem);
        EventManager.StopListening("SellerSelected", OnSelectedSeller);
    }

    #endregion

    #region VIRTUAL_METHODS

    protected virtual void ConfirmAction()
    {
        
    }

    protected virtual void StartListenEvents()
    {
        
    }

    protected virtual void StopListenEvents()
    {
        
    }

    protected virtual void ItemSelected()
    {
        
    }

    protected virtual void OnToggleValueChanged(bool arg0)
    {
        
    }
    #endregion

    #region LISTENER_METHODS
    /// <summary>
    /// When an item is selected it will fill the info
    /// </summary>
    /// <param name="arg0"></param>
    private void OnSelectedItem(object arg0)
    {
        selectedItem = (Item)arg0;
        txt_Name.text = selectedItem.itemName;
        txt_Description.text = selectedItem.description;
        txt_Cost.text = selectedItem.price.ToString();
        spriteItem.color = Color.white;
        spriteItem.sprite = selectedItem.itemIcon;
        
        ItemSelected();
    }
    
    /// <summary>
    /// When a seller is selected it will assign the item
    /// </summary>
    /// <param name="arg0"></param>
    private void OnSelectedSeller(object arg0)
    {
        selectedItem = null;
        EmptyInfo();
    }
    #endregion

    #region PROTECTED_METHODS
    /// <summary>
    /// It will empty the info when no object is selected
    /// </summary>
    protected void EmptyInfo()
    {
        txt_Name.text = string.Empty;
        txt_Description.text = String.Empty;
        txt_Cost.text = emptyValue;
        spriteItem.color = Color.clear;
        btnConfirm.interactable = false;
    }
    #endregion
    
}
