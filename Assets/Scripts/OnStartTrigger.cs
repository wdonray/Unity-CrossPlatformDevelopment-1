
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class OnStartTrigger : MonoBehaviour
{
    public OnStartEvent onStart;
    private void Start()
    {
        onStart.Invoke();
    }
}

[System.Serializable]
public class OnStartEvent : UnityEvent
{
}

