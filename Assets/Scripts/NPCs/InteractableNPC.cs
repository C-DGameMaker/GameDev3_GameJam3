using JetBrains.Annotations;
using TMPro;
using UnityEngine;
public class InteractableNPC : MonoBehaviour, IInteractable
{
    public string[] sentences = null;
    public TextMeshProUGUI promptText;

    public void HidePrompt()
    {
        promptText.text = "";
    }

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

    public void ShowPrompt()
    {
        promptText.text = "E";
    }
}
