using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class that loads between scenes
/// </summary>
public class LoadScene : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    /// <summary>
    /// Slider to measure the progress of the loading
    /// </summary>
    public Slider sliderProgress;
    /// <summary>
    /// Text progress to change while loading
    /// </summary>
    public TextMeshProUGUI textProgress;
    #endregion

    #region PUBLIC_METHODS
    /// <summary>
    /// Public method to load a new level, if it has a slider it will load async
    /// if not, it will just load the level
    /// </summary>
    /// <param name="levelIndex"></param>
    public void LoadLevel(int levelIndex)
    {
        if (sliderProgress == null)
            SceneManager.LoadScene(levelIndex);
        else
            StartCoroutine(LoadSceneCoroutine(levelIndex));
    }
    #endregion

    #region COROUTINES

    IEnumerator LoadSceneCoroutine(int sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress*100;
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            
            sliderProgress.value = progress;
            textProgress.text = progress.ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion
}
