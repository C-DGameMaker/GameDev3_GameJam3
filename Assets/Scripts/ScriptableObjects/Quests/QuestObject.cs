using System.Net.Http.Headers;
using UnityEditor.SearchService;
using UnityEngine;

public class QuestObject : ScriptableObject
{
    public string questName;
    public bool questCompleted;

    public void CompleteQuest()
    {
        questCompleted = true;
    }
}
