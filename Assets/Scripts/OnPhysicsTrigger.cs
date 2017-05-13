using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class OnPhysicsTrigger : MonoBehaviour
{
    [TagSelector]
    public string ListenerTag;

    public OnStart onStart = new OnStart();
    public OnEnterCollision onEnterCollision = new OnEnterCollision();
    public OnExitCollision onExitCollision = new OnExitCollision();
    public OnEnterTrigger onEnterTrigger = new OnEnterTrigger();
    public OnExitTrigger onExitTrigger = new OnExitTrigger();

    void Start()
    {
        onStart.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onEnterTrigger.Invoke(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onExitTrigger.Invoke(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onEnterCollision.Invoke(collision.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onExitCollision.Invoke(collision.gameObject);
    }


    [Serializable]
    public class OnStart : UnityEvent
    {
    }

    [Serializable]
    public class OnExitTrigger : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnEnterTrigger : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnEnterCollision : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class OnExitCollision : UnityEvent<GameObject>
    {
    }


#if UNITY_EDITOR

    

#endif
}