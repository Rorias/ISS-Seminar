using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    private List<Dialogue> allDialogues = new List<Dialogue>();
    private int currentSentence = 0;

    [HideInInspector] public bool finishedDialogue = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        textBox.SetActive(false);

        List<DialogueHandler> allHandlers = FindObjectsOfType<DialogueHandler>().ToList();

        for (int i = 0; i < allHandlers.Count; i++)
        {
            for (int j = 0; j < allHandlers[i].dialogues.Count; j++)
            {
                allDialogues.Add(allHandlers[i].dialogues[j]);
            }
        }
    }

    private void Update()
    {
        if (textBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            currentSentence++;
            UpdateDialogue();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Dialogue tempDia = null;

            switch (GameManager.currentDay)
            {
                case 0:
                    tempDia = allDialogues.Find(x => x.id == 1 && x.charName == "Newcomer");
                    break;
                case 1:
                    tempDia = allDialogues.Find(x => x.id == 5 && x.charName == "Newcomer");
                    break;
                case 2:
                    tempDia = allDialogues.Find(x => x.id == 12 && x.charName == "Newcomer");
                    break;
                case 3:
                    tempDia = allDialogues.Find(x => x.id == 17 && x.charName == "Newcomer");
                    break;
                case 4:
                    tempDia = allDialogues.Find(x => x.id == 22 && x.charName == "Newcomer");
                    break;
                case 5:
                    tempDia = allDialogues.Find(x => x.id == 28 && x.charName == "Newcomer");
                    break;
                case 6:
                    tempDia = allDialogues.Find(x => x.id == 35 && x.charName == "Newcomer");
                    break;
                case 7:
                    tempDia = allDialogues.Find(x => x.id == 42 && x.charName == "Newcomer");
                    break;
                default:
                    break;
            }

            tempDia.dialogueEndEvent.Invoke();
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
            player.locked = false;
            currentDialogue.dialogueEndEvent?.Invoke();
            textBox.SetActive(false);
            finishedDialogue = true;
            currentSentence = 0;
        }
    }
}
