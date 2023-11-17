using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOver : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Canvas canvasWin;
    #endregion

    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening("GameOver",OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.StopListening("GameOver",OnGameOver);
    }
    #endregion

    #region LISTENER_METHODS

    private void OnGameOver(object arg)
    {
        if ((bool)arg)
            canvasWin.enabled = true;
    }
    #endregion
}
