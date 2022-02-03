using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;
using UnityEngine.UI;

public class ChoiceSystem : MonoBehaviour
{
    private List<GameObject> choices = new List<GameObject>();

    private GameObject currentMenu;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            choices.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < choices.Count; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void OpenChoiceMenu(int _choiceID)
    {
        currentMenu = choices[_choiceID];

        currentMenu.SetActive(true);
    }

    private void CloseChoiceMenu()
    {
        currentMenu.SetActive(false);
    }
}
