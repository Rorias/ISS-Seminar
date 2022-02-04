using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ScreenFader fading;
    private Vector2 tempPos = Vector2.zero;
    public static int currentDay { get; private set; } = 0;

    private void Awake()
    {
        fading = GameObject.Find("Fader").GetComponent<ScreenFader>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene _s, LoadSceneMode _lsm)
    {

    }

    public void MoveCharPosX(float _xPos)
    {
        tempPos = new Vector2(_xPos, tempPos.y);
    }

    public void MoveCharPosY(float _yPos)
    {
        tempPos = new Vector2(tempPos.x, _yPos);
    }

    public void MoveCharChar(GameObject _char)
    {
        _char.transform.position = tempPos;
    }

    public void FadeOut()
    {
        fading.FadeOut(Color.black);
    }

    public void FadeIn()
    {
        fading.FadeIn();
    }

    public void SetDay(int _day)
    {
        currentDay = _day;
    }
}
