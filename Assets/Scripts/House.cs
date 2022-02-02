using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;


public class House : MonoBehaviour
{
    public string houseName;
    public Vector2 location;
    [HideInInspector] public Vector2 teleportLocation;

    private PlayerMovement player;

    private GameObject playerCanvas;
    private TextMeshProUGUI text;

    private bool inRange = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerCanvas = GameObject.Find("PlayerText");
        text = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            teleportLocation = player.transform.position;
            player.transform.position = location;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.CompareTag("Player"))
        {
            inRange = true;
            playerCanvas.SetActive(true);
            text.text = "Press 'E' to enter " + houseName;
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
}
