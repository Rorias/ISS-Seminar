using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using TMPro;

public class DialogueHandler : MonoBehaviour
{
    private PlayerMovement player;

    private DialogueManager diaMng;
    public List<Dialogue> dialogues = new List<Dialogue>();

    private GameObject playerCanvas;
    private TextMeshProUGUI text;

    private bool inRange = false;
    private int currentDialogue = 0;


    private void Awake()
    {
        diaMng = GameObject.Find("GameManager").GetComponent<DialogueManager>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerCanvas = GameObject.Find("PlayerText");
        text = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && !diaMng.textBox.activeSelf && !diaMng.finishedDialogue && dialogues[currentDialogue].available)
        {
            diaMng.StartDialogue(dialogues[currentDialogue]);
            player.locked = true;

            if (currentDialogue < dialogues.Count - 1 && currentDialogue + 1 < dialogues.Count && dialogues[currentDialogue + 1].available)
            {
                currentDialogue++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.CompareTag("Player") && dialogues[currentDialogue].available)
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

    public void SetDialoguesAvailable(int _id)
    {
        for (int i = 0; i < dialogues.Count; i++)
        {
            if (dialogues[i].id == _id)
            {
                dialogues[i].available = true;
            }
        }

        if (dialogues[currentDialogue].id < _id)
        {
            currentDialogue++;
        }
    }
}
