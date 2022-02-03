using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScreenFader fading;
    private Vector2 tempPos = Vector2.zero;

    private void Awake()
    {
        fading = GameObject.Find("Fader").GetComponent<ScreenFader>();
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
}
