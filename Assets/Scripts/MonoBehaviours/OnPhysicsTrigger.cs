using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnPhysicsTrigger : MonoBehaviour
{


    [System.Serializable]
    public class OnExitTrigger : UnityEvent { }
    [System.Serializable]
    public class OnEnterTrigger : UnityEvent { }
    [System.Serializable]
    public class OnEnterCollsion : UnityEvent<string> { }
    [System.Serializable]
    public class OnExitCollision : UnityEvent<string> { }
    [System.Serializable]
    public class OnStart : UnityEvent { }


    public OnEnterCollsion onEnterCollsision = new OnEnterCollsion();
    public OnExitCollision onExitCollision = new OnExitCollision();
    public OnExitTrigger onExitTrigger = new OnExitTrigger();
    public OnEnterTrigger onTriggerEnter = new OnEnterTrigger();
    public OnStart onStart = new OnStart();
    private void Start()
    {
        onStart.Invoke();
    }

    public string ListenerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            onTriggerEnter.Invoke();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            onExitTrigger.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(ListenerTag))
            onEnterCollsision.Invoke(collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(ListenerTag))
            onExitCollision.Invoke(collision.gameObject.tag);
    }
}