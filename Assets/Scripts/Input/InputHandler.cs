using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle the Input for the app to be easier to change Input across platforms
/// </summary>
public class InputHandler
{
    /// <summary>
    /// Horizontal value 
    /// </summary>
    public static float horizontal { get { return HandleHorizontal(); } }

    /// <summary>
    /// Vertical value
    /// </summary>
    public static float vertical { get { return HandleVertical(); } }

    /// <summary>
    /// Submit value
    /// </summary>
    public static bool action { get { return HandleAction(); } }
    
    public static bool attack { get { return HandleAttack(); } }

    #region PRIVATE_METHODS
    /// <summary>
    /// In PC or console it will be the "Horizontal" value, in mobile a UI horizontal Joystick
    /// </summary>
    /// <returns>Value from -1 to 1</returns>
    private static float HandleHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// In PC or console it will be the "Vertical" value, in mobile a UI vertical Joystick
    /// </summary>
    /// <returns>Value from -1 to 1</returns>
    private static float HandleVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// In PC or console it will be the "Submit" axis, in mobile a UI Button
    /// </summary>
    /// <returns></returns>
    private static bool HandleAction()
    {
        return Input.GetButtonDown("Submit");
    }

    /// <summary>
    /// In PC or console it will be the "Fire1" axis, in mobile a UI Button
    /// </summary>
    /// <returns></returns>
    private static bool HandleAttack()
    {
        return Input.GetButtonDown("Fire1");
    }
    #endregion
    
}
