using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject prefabQuest;
    public Quest sleepQuest;

    public List<Quest> quests = new List<Quest>();

    private bool questsCompleted = false;

    public void CreateQuest(Quest _quest)
    {
        GameObject newQuest = Instantiate(prefabQuest, GameObject.Find("QuestList").transform);
        quests.Add(_quest);
        _quest.linkedText = newQuest.GetComponent<TextMeshProUGUI>();
        _quest.InitializeQuest();
    }

    public void Update()
    {
        if (questsCompleted)
        {
            for (int i = 0; i < quests.Count; i++)
            {
                if (!quests[i].completed) { return; }
            }

            questsCompleted = true;

            CreateQuest(sleepQuest);
        }
    }

    private void ClearQuests()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            Destroy(quests[i].gameObject);
        }

        quests.Clear();
    }
}
