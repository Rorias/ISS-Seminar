using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public bool completed;
    public string title;

    public void InitializeQuest()
    {
        GetComponent<TextMeshProUGUI>().text = title;
    }

    public void FinishQuest()
    {
        if (!completed)
        {
            GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        }

        completed = true;
    }
}
