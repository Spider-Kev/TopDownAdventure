using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

/// <summary>
/// Dialogue Manager class to handle conversations
/// </summary>
public class DialogueManager : MonoBehaviour
{

    #region PUBLIC_VARIABLES
    /// <summary>
    /// Conversation text
    /// </summary>
    public TMP_Text dialogueText;
    /// <summary>
    /// Name of the speaker of this Dialogue
    /// </summary>
    public TMP_Text speaker;
    /// <summary>
    /// Panel to show when dialogue starts
    /// </summary>
    public Canvas dialoguePanel;
    /// <summary>
    /// Typing speed to show int he conversation text
    /// </summary>
    public float typingSpeed = 0.05f;
    #endregion

    #region PRIVATE_VARIABLES
    /// <summary>
    /// It will use a queue to catch the strings send by the Dialogue
    /// </summary>
    private Queue<string> dialogueQueue;
    /// <summary>
    /// Current string dequeued from the dialogueQueue 
    /// </summary>
    private string currentString;
    /// <summary>
    /// Set if the text is being writing
    /// </summary>
    private bool isTyping = false;
    #endregion


    #region UNITY_METHODS
    void Start()
    {
        dialogueQueue = new Queue<string>();
    }

    /// <summary>
    /// Observer pattern waiting for StartDialogue message
    /// </summary>
    private void OnEnable()
    {
        EventManager.StartListening("StartDialogue",OnStartDialogue);
    }

    private void OnDisable()
    {
        EventManager.StopListening("StartDialogue",OnStartDialogue);
    }

    /// <summary>
    /// If the panel is enabled and action button pressed, it will display the next Sentence
    /// </summary>
    private void Update()
    {
        if (dialoguePanel.enabled && InputHandler.action)
            DisplayNextSentence();
    }
    #endregion


    #region PUBLIC_METHODS
    /// <summary>
    /// It will start a new Dialogue, enabling also the panel
    /// </summary>
    /// <param name="dialogues">Dialogue with string array of conversations and speaker name</param>
    public void StartDialogue(Dialogue dialogues)
    {
        dialoguePanel.enabled = true;
        speaker.text = dialogues.speaker;
        dialogueQueue.Clear();
        foreach (string dialogue in dialogues.textDialogue)
        {
            dialogueQueue.Enqueue(dialogue);
        }
        DisplayNextSentence();
    }

    /// <summary>
    /// It will display the next sentence, if is currently writing, it will skip the write
    /// Otherwise it will end the conversation
    /// </summary>
    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            isTyping = false;
            dialogueText.text = currentString;
            return;
        }
        
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = GetCurrentDialogue();
        StartCoroutine(RoutineTypeSentence(sentence));
    }
    

    #endregion
    
    #region PRIVATE_METHODS
    /// <summary>
    /// Finish the dialogue closing the canvas and starting the routine to reactivate the block
    /// </summary>
    private void EndDialogue()
    {
        dialoguePanel.enabled = false;
        StartCoroutine(RoutineCloseDialogue());
    }
    
    /// <summary>
    /// Get the current string to show from the queue
    /// </summary>
    /// <returns></returns>
    private string GetCurrentDialogue()
    {
        currentString =dialogueQueue.Dequeue();
        return currentString;
    }
    #endregion

    #region LISTENER_METHODS
    /// <summary>
    /// Start the new dialogue
    /// </summary>
    /// <param name="arg0">Dialogue to be showed</param>
    private void OnStartDialogue(object arg0)
    {
        StartDialogue((Dialogue)arg0);
    }
    #endregion
    
    #region ROUTINES
    /// <summary>
    /// Routine to wait for the typingSpeed in order to show a new character
    /// from the complete sentence
    /// </summary>
    /// <param name="sentence">The complete sentence to be displayed</param>
    /// <returns></returns>
    IEnumerator RoutineTypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    /// <summary>
    /// Waits for a frame to unblock the controls, otherwise it will trigger again the conversation
    /// </summary>
    /// <returns></returns>
    IEnumerator RoutineCloseDialogue()
    {
        yield return new WaitForEndOfFrame();
        EventManager.TriggerEvent("ShowedPanel",false);
    }
    #endregion
}