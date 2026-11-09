using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<QuestObject> allQuests = new List<QuestObject>();
    public List<QuestObject> completedQuests = new List<QuestObject>();

    public void Awake()
    {
        if(allQuests == null)
        {

        }
    }
}
