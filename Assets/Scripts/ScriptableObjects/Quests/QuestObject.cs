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

    public List<QuestObjective> objectives = new List<QuestObjective>();
    public QuestReward reward;

    [Header("Prerequisites")]
    public List<string> requiredCompletedQuests;
    public int requiredPlayerLevel;

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
    Collect,
    Talk,
    Interact,
    Attack
}

