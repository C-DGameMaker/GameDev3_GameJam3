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
    }

    public void CheckQuestStatus()
    {
        if (QuestManager.questInstance.completedQuestName.Contains(quest.questName))
        {
            sentences = postQuestDialogue;
            return;
        }

        if (!QuestManager.questInstance.activeQuests.ContainsKey(quest.questName))
        {
            sentences = preQuestDialogue;
            QuestManager.questInstance.AcceptQuest(quest);
            return;
        }

        foreach (string s in Inventory.playerInventory.itemGotten)
        {
            foreach (var obv in quest.objectives)
            {
                if (s == obv.targetName)
                {
                    QuestManager.questInstance.ReportProgress(QuestObjectiveType.Collect, s);

                    if (QuestManager.questInstance.completedQuestName.Contains(quest.questName))
                    {
                        sentences = finishQuestDialogue;
                    }
                    else
                    {
                        sentences = duringQuestDialogue;
                    }

                    return;
                }
            }
        }

        sentences = duringQuestDialogue;
    }
}
