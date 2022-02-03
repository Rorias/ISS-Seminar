using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Dialogue
{
    public string dialogueName;
    public string charName;
    public bool available;
    public int id;
    public Color charColor;

    [TextArea(3, 10)]
    public string[] charSentences;
    public UnityEvent dialogueEndEvent;
}
