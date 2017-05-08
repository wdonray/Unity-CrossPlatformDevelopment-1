using System;
using UnityEngine;
using UnityEngine.Events;

public class OnPhysicsTrigger : MonoBehaviour
{
    public string ListenerTag;


    public OnEnterCollsion onEnterCollsision = new OnEnterCollsion();
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
        if (collision.gameObject.CompareTag("Player"))
            onTriggerEnter.Invoke();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            onExitTrigger.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onEnterCollsision.Invoke(collision.gameObject.name);
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
    public class OnEnterTrigger : UnityEvent
    {
    }

    [Serializable]
    public class OnEnterCollsion : UnityEvent<string>
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