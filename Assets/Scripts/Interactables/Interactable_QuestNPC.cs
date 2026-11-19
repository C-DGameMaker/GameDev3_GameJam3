using UnityEngine;

public class Interactable_QuestNPC : MonoBehaviour, IInteractable
{
    public GameManager gameManager;
    public string[] sentences;

    public string[] preQuestDialogue;
    public string[] duringQuestDialogue;
    public string[] finishQuestDialogue;
    public string[] postQuestDialogue;
    public QuestObject quest;
    public void Interact()
    {
        CheckQuestStatus();
        if (GameManager.Instance.dialogueManager.inDialogue == true)
        {
            GameManager.Instance.dialogueManager.DisplayNextString();
        }
        else
        {
            GameManager.Instance.dialogueManager.StartDialogue(sentences);
        }

        if (!QuestManager.questInstance.activeQuests.ContainsKey(quest.questName))
        {
            QuestManager.questInstance.AcceptQuest(quest);
        }
    }

    public void CheckQuestStatus()
    {
        if (!QuestManager.questInstance.activeQuests.ContainsKey(quest.questName))
        {
            sentences = preQuestDialogue;
        }
        else if(QuestManager.questInstance.completedQuestName.Contains(quest.questName))
        {
            sentences = postQuestDialogue;
        }
        
        
    }
}
