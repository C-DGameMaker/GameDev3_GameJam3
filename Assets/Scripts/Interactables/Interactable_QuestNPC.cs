using UnityEngine;

public class Interactable_QuestNPC : MonoBehaviour, IInteractable
{
    public QuestObject quest;
    public void Interact()
    {
        QuestManager.questInstance.AcceptQuest(quest);
    }
}
