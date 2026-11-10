using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public GameManager gameManager;
    public string[] sentences = null;

    public void Interact()
    {
        if (GameManager.Instance.dialogueManager.inDialogue == true)
        {
            GameManager.Instance.dialogueManager.DisplayNextString();
        }
        else
        {
            GameManager.Instance.dialogueManager.StartDialogue(sentences);
        }
    }
}
