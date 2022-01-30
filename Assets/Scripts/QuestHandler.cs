using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class QuestHandler : MonoBehaviour
{
    public UnityEvent questFinishEvent;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            questFinishEvent.Invoke();
        }
    }
}
