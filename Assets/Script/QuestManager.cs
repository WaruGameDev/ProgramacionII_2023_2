using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QUEST_STATUS
{
    UNASSIGNED, ASSIGNED, COMPLETE
}
[System.Serializable]
public class Quest
{
    public string nameQuest;
    public QUEST_STATUS questStatus;
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeQuestStatus(string questToChange, QUEST_STATUS newQuestStatus)
    {
        foreach (Quest quest in quests)
        {
            if (quest.nameQuest == questToChange)
            {
                quest.questStatus = newQuestStatus;
            }
        }
    }

    public QUEST_STATUS GetQuestStatus(string questToGetStatus)
    {
        foreach (Quest quest in quests)
        {
            if (quest.nameQuest == questToGetStatus)
            {
                return quest.questStatus;
            }
        }

        return QUEST_STATUS.UNASSIGNED;
    }

    public void AddQuest(string newQuest)
    {
        foreach (var quest in quests)
        {
            if (quest.nameQuest == newQuest)
            {
                return;
            }
        }
        Quest q = new Quest();
        q.nameQuest = newQuest;
        q.questStatus = QUEST_STATUS.ASSIGNED;
        quests.Add(q);
    }
}

