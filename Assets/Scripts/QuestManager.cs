using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject prefabQuest;

    public List<Quest> quests = new List<Quest>();

    public void CreateQuest(Quest _quest)
    {
        GameObject newQuest = Instantiate(prefabQuest, GameObject.Find("QuestList").transform);
        quests.Add(_quest);
        _quest.linkedText = newQuest.GetComponent<TextMeshProUGUI>();
        _quest.InitializeQuest();
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
