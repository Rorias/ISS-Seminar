using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject prefabQuest;

    public List<Quest> quests = new List<Quest>();

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateQuest("This is a Test");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearQuests();
        }
    }

    private void CreateQuest(string _title)
    {
        GameObject newQuest = Instantiate(prefabQuest, transform);
        Quest quest = newQuest.GetComponent<Quest>();
        quests.Add(quest);
        quest.title = _title;
        quest.InitializeQuest();
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
