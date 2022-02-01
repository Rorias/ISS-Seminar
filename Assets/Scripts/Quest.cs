using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI linkedText;
    public string title;
    public int chainLength;

    [HideInInspector] public bool completed;
    
    private int currentStep = 0;
    private bool available = false;

    public void InitializeQuest()
    {
        linkedText.text = title + (chainLength > 1 ? " (" + currentStep + "/" + chainLength + ")" : "");
        available = true;
    }

    public void UpdateQuestStatus()
    {
        if (currentStep < chainLength)
        {
            currentStep++;
            linkedText.text = title + (chainLength > 1 ? " (" + currentStep + "/" + chainLength + ")" : "");

            if (currentStep == chainLength)
            {
                FinishQuest();
            }
        }
    }

    private void FinishQuest()
    {
        if (!completed)
        {
            linkedText.fontStyle = FontStyles.Strikethrough;
        }

        completed = true;
    }
}
