using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questInstance { get; private set; }
    public QuestObject[] allQuests;

    public Dictionary<string, ActiveQuest> activeQuests = new();
    public HashSet<string> completedQuestName = new();
    public event Action<ActiveQuest> OnQuestAccepted;
    public event Action<ActiveQuest> OnQuestCompleted;
    public event Action<string, int, int> OnObjectiveProgress;


    public void Awake()
    {
        if (questInstance != null) Destroy(this.gameObject);

        questInstance = this;

        if(allQuests == null)
        {
            Debug.Log("No Quests");
        }
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
        OnQuestAccepted?.Invoke(accepetedQuest);
        Debug.Log("AcceptedQuest");
    }

    public void ReportProgress(QuestObjectiveType type, string targetName, int amount = 1)
    {
        foreach (var kvp in activeQuests)
        {
            ActiveQuest quest = kvp.Value;
            foreach (var obj in quest.objectives)
            {
                if (obj.isComplete) continue;
                if (obj.questObjective.type != type) continue;
                if (obj.questObjective.targetName != targetName) continue;

                obj.currentAmount = Mathf.Min(obj.currentAmount + amount, obj.questObjective.requiredAmount);
                
                OnObjectiveProgress?.Invoke(obj.questObjective.objectiveName, obj.currentAmount,obj.questObjective.requiredAmount);
            }

            if (quest.AllObjectivesComplete && !quest.completed) CompleteQuest(quest);
            
        }
    }

    private void CompleteQuest(ActiveQuest quest)
    {
        quest.completed = true;
        activeQuests.Remove(quest.activeQuest.questName);
        completedQuestName.Add(quest.activeQuest.questName);
        OnQuestCompleted?.Invoke(quest);
        Debug.Log("CompletedQuest");
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

