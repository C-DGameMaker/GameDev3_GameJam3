using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Data", menuName = "Quest")]
public class QuestObject : ScriptableObject
{
    public string questName;
    [TextArea(3, 6)]
    public string questDescription;
    public bool questCompleted;

    public List<QuestObjective> objectives = new List<QuestObjective>();
    public QuestReward reward;

    public void CompleteQuest()
    {
        questCompleted = true;
    }
}

[System.Serializable]
public class QuestObjective
{
    public string objectiveDescription;
    public QuestObjectiveType type;
    public int requiredAmount;
}

[System.Serializable]
public class QuestReward
{
    public string rewardDescription;
    public int gold;
    public List<string> itemIds;
}

public enum QuestObjectiveType
{
    Kill,
    Collect,
    Talk,
    Reach,
    Interact
}

