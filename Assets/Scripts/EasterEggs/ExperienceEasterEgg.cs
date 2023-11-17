using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is an easter egg to show my years of experience in Game Development
/// </summary>
public class ExperienceEasterEgg : MonoBehaviour
{
    #region PUBLIC_VARIABLES
/// <summary>
/// Fill the info in this fields
/// </summary>
    public TextMeshProUGUI experiencePercentage;
    public TextMeshProUGUI experienceYears;
    public Slider sliderExperience;

    #endregion

    #region UNITY_METHODS

    private void Start()
    {
        GetExperience();
    }
    #endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// Calculate according to years of experience I have
    /// starting in August 2012 (Date I started to work professional)
    /// </summary>
    private void GetExperience()
    {
        int years = System.DateTime.Now.Year - 2012;
        float percentage = (1f / 11f) * (DateTime.Now.Month - 1);
        experienceYears.text = years.ToString();
        experiencePercentage.text = (percentage*100).ToString("##.#");
        sliderExperience.value = percentage * 100;

    }
    #endregion
}
