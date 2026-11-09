using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Data", menuName = "Quest")]
public class QuestObject : ScriptableObject
{
    public string questName;
    public bool questCompleted;

    public List<QuestObjective> objectives = new List<QuestObjective>();

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

public enum QuestObjectiveType
{
    Kill,
    Collect,
    Talk,
    Reach,
    Interact
}

