using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DialogueManager : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject textBox;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charText;

    private Dialogue currentDialogue;
    private int currentSentence = 0;

    [HideInInspector] public bool finishedDialogue = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        textBox.SetActive(false);
    }

    private void Update()
    {
        if (textBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            currentSentence++;
            UpdateDialogue();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            finishedDialogue = false;
        }
    }

    public void StartDialogue(Dialogue _dia)
    {
        textBox.SetActive(true);

        currentDialogue = _dia;

        textBox.GetComponent<Image>().color = currentDialogue.charColor;
        charName.text = currentDialogue.charName;
        charText.text = currentDialogue.charSentences[0];
    }

    private void UpdateDialogue()
    {
        if (currentSentence < currentDialogue.charSentences.Length)
        {
            charText.text = currentDialogue.charSentences[currentSentence];
        }
        else
        {
            currentDialogue.dialogueEndEvent?.Invoke();
            textBox.SetActive(false);
            finishedDialogue = true;
            currentSentence = 0;
            player.locked = false;
        }
    }
}
