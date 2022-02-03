using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject prefabQuest;

    private List<Quest> allQuests = new List<Quest>();
    public List<Quest> currentQuests = new List<Quest>();

    private int minCompletion = 1;

    private bool questsCompleted = false;

    private void Awake()
    {
        Transform quests = GameObject.Find("Quests").transform;

        for (int i = 0; i < quests.childCount; i++)
        {
            allQuests.Add(quests.transform.GetChild(i).GetComponent<Quest>());
        }
    }

    public void CreateQuest(Quest _quest)
    {
        GameObject newQuest = Instantiate(prefabQuest, GameObject.Find("QuestList").transform);
        currentQuests.Add(_quest);
        _quest.linkedText = newQuest.GetComponent<TextMeshProUGUI>();
        _quest.InitializeQuest();
    }

    public void Update()
    {
        if (!questsCompleted && allQuests.FindAll(x => x.fromDay == GameManager.currentDay && !x.completed).Count <= minCompletion)
        {
            questsCompleted = true;

            CreateQuest(allQuests.Find(x => x.name == ("Sleep" + GameManager.currentDay)));
        }
    }

    public void ClearQuests()
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            Destroy(currentQuests[i].linkedText.gameObject);
        }

        currentQuests.Clear();
    }

    public void SetMinCompletionForDay(int _minQuestsRequired)
    {
        minCompletion = _minQuestsRequired;
    }
}
