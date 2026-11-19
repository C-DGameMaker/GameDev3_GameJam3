using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> dialogueQueue;

    public GameManager gameManager;

    public bool inDialogue = false;

    private void Awake()
    {
        dialogueQueue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        GameManager.Instance.UIManager.ShowDialoguePanel();
        inDialogue = true;
        PlayerController.movementController.canMove = false;

        foreach (string currentString in sentences)
        {
            dialogueQueue.Enqueue(currentString);
        }

        DisplayNextString();

        Debug.Log($"Interacted with {gameObject.name}");
    }

    public void DisplayNextString()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
        }
        else if (dialogueQueue.Count > 0)
        {
            GameManager.Instance.UIManager.SetDialogueText(dialogueQueue.Dequeue());
        }
    }

    private void EndDialogue()
    {
        dialogueQueue.Clear();
        GameManager.Instance.UIManager.HideDialoguePanel();
        inDialogue = false;
        PlayerController.movementController.canMove = true;
    }
}
