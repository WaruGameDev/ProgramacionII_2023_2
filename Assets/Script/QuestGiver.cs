using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public void AddQuest(string questToAdd)
    {
        QuestManager.instance.AddQuest(questToAdd);
    }
}
