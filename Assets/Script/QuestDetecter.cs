using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDetecter : MonoBehaviour
{
    public UnityEvent onQuestDetected;
    public Quest questToDetect;

    private void Update()
    {
        Detect();
    }

    public void Detect()
    {
        if (QuestManager.instance.GetQuestStatus(questToDetect.nameQuest) == QUEST_STATUS.ASSIGNED)
        {
            onQuestDetected?.Invoke();
        }
       
    }
}
