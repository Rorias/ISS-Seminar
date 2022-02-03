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
    private bool changingRoom = false;

    private ScreenFader fading;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerCanvas = GameObject.Find("PlayerText");
        text = GameObject.Find("InteractText").GetComponent<TextMeshProUGUI>();
        fading = GameObject.Find("Fader").GetComponent<ScreenFader>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && !changingRoom)
        {
            StartCoroutine(LoadZone());
        }
    }

    private IEnumerator LoadZone()
    {
        changingRoom = true;
        player.locked = true;
        fading.FadeOut(Color.black);

        yield return new WaitUntil(() => fading.doneFadingOut);

        teleportLocation = player.transform.position;
        player.transform.position = location;
        Camera.main.orthographicSize = 4.5f;

        fading.FadeIn();
        changingRoom = false;
        player.locked = false;
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
