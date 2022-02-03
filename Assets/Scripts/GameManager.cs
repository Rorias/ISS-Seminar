using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 tempPos = Vector2.zero;

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
}
