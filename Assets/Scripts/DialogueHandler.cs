using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public DialogueManager diaMng;
    public List<Dialogue> dialogues = new List<Dialogue>();

    private GameObject playerCanvas;
    private TextMeshProUGUI text;

    private bool inRange = false;
    private int currentDialogue = 0;


    private void Awake()
    {
        playerCanvas = GameObject.Find("PlayerText");
        text = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && !diaMng.textBox.activeSelf && !diaMng.finishedDialogue)
        {
            diaMng.StartDialogue(dialogues[currentDialogue]);

            if (currentDialogue < dialogues.Count - 1)
            {
                currentDialogue++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.CompareTag("Player"))
        {
            inRange = true;
            playerCanvas.SetActive(true);
            text.text = "Press 'E' to interact with " + name;
        }
    }

    private void OnTriggerExit2D(Collider2D _coll)
    {
        if (_coll.CompareTag("Player"))
        {
            inRange = false;
            playerCanvas.SetActive(false);
        }
    }

    public void StartQuest(Quest _quest)
    {

    }
}
