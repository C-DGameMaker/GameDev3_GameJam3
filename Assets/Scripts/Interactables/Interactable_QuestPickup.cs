using UnityEngine;
using static UnityEditor.Progress;

public class Interactable_QuestPickup : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    public void Interact()
    {
        QuestManager.questInstance.ReportProgress(QuestObjectiveType.Collect, itemName);
        Destroy(gameObject);
        Debug.Log("You got cat.");
    }
}
