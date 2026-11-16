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
    private HashSet<string> completedQuestIds = new();

    public void Awake()
    {
        if (questInstance != null) Destroy(this.gameObject);

        questInstance = this;
    }

    public bool CanAcceptQuest(QuestObject def)
    {
        if (activeQuests.ContainsKey(def.questID)) return false;
        if (completedQuestIds.Contains(def.questID)) return false;

        foreach (string reqId in def.requiredCompletedQuests)
        {
            if (!completedQuestIds.Contains(reqId)) return false;
        }
        return true;
    }

    public void AcceptQuest(QuestObject def)
    {
        if (!CanAcceptQuest(def)) return;

        var active = new ActiveQuest(def);
        activeQuests[def.questID] = active;
    }

    private void CompleteQuest(ActiveQuest quest)
    {
        quest.completed = true;
        activeQuests.Remove(quest.questDef.questID);
        completedQuestIds.Add(quest.questDef.questID);
    }
}

public class ActiveQuest
{
    public QuestObject questDef;
    public List<ActiveObjective> objectives = new();
    public bool completed;

    public bool AllObjectivesComplete => objectives.All(o => o.isComplete);

    public ActiveQuest(QuestObject def)
    {
        questDef = def;
        foreach(var objDef in def.objectives)
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


