using TMPro;
using UnityEngine;

public class Interactable_QuestPickup : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    public TextMeshProUGUI promptText;
    public void Interact()
    {
        Inventory.playerInventory.AddToInventory(itemName);
        Destroy(gameObject);
        Debug.Log("You got cat.");
    }

    public void ShowPrompt()
    {
        promptText.text = "E";
    }
    public void HidePrompt()
    {
        promptText.text = "";
    }
}
