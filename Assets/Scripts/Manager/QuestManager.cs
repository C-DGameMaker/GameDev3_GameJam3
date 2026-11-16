using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questInstance { get; private set; }
    public QuestObject[] allQuests;

    private Dictionary<string, ActiveQuest> activeQuests = new();
    private HashSet<string> completedQuestName = new();

    public void Awake()
    {
        if (questInstance != null) Destroy(this.gameObject);

        questInstance = this;
    }

    public bool CanAcceptQuest(QuestObject quest)
    {
        if (activeQuests.ContainsKey(quest.questName)) return false;
        if (completedQuestName.Contains(quest.questName)) return false;

        foreach (string completedQuestName in quest.requiredCompletedQuests)
        {
            if (!this.completedQuestName.Contains(completedQuestName)) return false;
        }
        return true;
    }

    public void AcceptQuest(QuestObject quest)
    {
        if (!CanAcceptQuest(quest)) return;

        ActiveQuest accepetedQuest = new ActiveQuest(quest);
        activeQuests[quest.questName] = accepetedQuest;
    }

    private void CompleteQuest(ActiveQuest quest)
    {
        quest.completed = true;
        activeQuests.Remove(quest.activeQuest.questName);
        completedQuestName.Add(quest.activeQuest.questName);

        // Get rewards (Figure out how)
    }
}

public class ActiveQuest
{
    public QuestObject activeQuest;
    public List<ActiveObjective> objectives = new();
    public bool completed;

    public bool AllObjectivesComplete => objectives.All(o => o.isComplete);

    public ActiveQuest(QuestObject quest)
    {
        activeQuest = quest;
        foreach(var objDef in quest.objectives)
        {
            objectives.Add(new ActiveObjective(objDef));
        }
    }

}

public class ActiveObjective
{
    public QuestObjective questObjective;
    public int currentAmount;
    public bool isComplete => currentAmount >= questObjective.requiredAmount;

    public ActiveObjective(QuestObjective def)
    {
        questObjective = def;
    }
}


