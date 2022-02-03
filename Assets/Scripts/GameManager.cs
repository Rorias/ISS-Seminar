using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 tempPos = Vector2.zero;

    public void MoveCharPos(Vector2 _position)
    {
        tempPos = _position;
    }

    public void MoveCharChar(GameObject _char)
    {
        _char.transform.position = tempPos;
    }
}
