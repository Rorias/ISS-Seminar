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
    private PlayerMovement player;

    public bool menuActive { get; private set; } = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

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
        player.locked = true;
        menuActive = true;
    }

    public void CloseChoiceMenu()
    {
        currentMenu.SetActive(false);
        player.locked = false;
        menuActive = false;
    }
}
