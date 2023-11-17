using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicControl : MonoBehaviour
{
    #region PUBLIC_VARIABLES

    public AudioSource source;
    public AudioClip winClipOneShot;
    public AudioClip winClip;
    #endregion
    
    #region UNITY_METHODS
    private void OnEnable()
    {
        EventManager.StartListening("GameOver", OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.StopListening("GameOver", OnGameOver);
    }
    #endregion

    #region LISTENER_METHODS
    private void OnGameOver(object arg0)
    {
        source.Stop();
        source.PlayOneShot(winClipOneShot);
        source.clip = winClip;
        source.PlayDelayed(winClipOneShot.length);
    }
    #endregion

}
