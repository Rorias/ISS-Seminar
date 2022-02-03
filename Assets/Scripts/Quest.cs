using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public UnityEvent onQuestFinish;
    public TextMeshProUGUI linkedText;
    public string title;
    public int chainLength;

    [HideInInspector] public bool completed;
    private bool available = false;

    private int currentStep = 0;

    private void Awake()
    {
        if (linkedText != null)
        {
            linkedText.text = title + (chainLength > 1 ? " (" + currentStep + "/" + chainLength + ")" : "");
            available = true;
        }
    }

    public void InitializeQuest()
    {
        linkedText.text = title + (chainLength > 1 ? " (" + currentStep + "/" + chainLength + ")" : "");
        available = true;
    }

    public void UpdateQuestStatus()
    {
        if (currentStep < chainLength && available)
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
            onQuestFinish?.Invoke();
        }

        completed = true;
    }
}
