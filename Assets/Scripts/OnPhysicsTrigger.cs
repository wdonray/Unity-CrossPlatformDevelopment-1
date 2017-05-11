using System;
using UnityEngine;
using UnityEngine.Events;

public class OnPhysicsTrigger : MonoBehaviour
{
    public string ListenerTag;

    public OnEnterCollision onEnterCollision = new OnEnterCollision();
    public OnExitCollision onExitCollision = new OnExitCollision();
    public OnExitTrigger onExitTrigger = new OnExitTrigger();
    public OnStart onStart = new OnStart();
    public OnEnterTrigger onTriggerEnter = new OnEnterTrigger();

    private void Start()
    {
        onStart.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onTriggerEnter.Invoke(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onExitTrigger.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onEnterCollision.Invoke(collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onExitCollision.Invoke(collision.gameObject.tag);
    }

    [Serializable]
    public class OnExitTrigger : UnityEvent
    {
    }

    [Serializable]
    public class OnEnterTrigger : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnEnterCollision : UnityEvent<string>
    {
    }

    [Serializable]
    public class OnExitCollision : UnityEvent<string>
    {
    }

    [Serializable]
    public class OnStart : UnityEvent
    {
    }
}