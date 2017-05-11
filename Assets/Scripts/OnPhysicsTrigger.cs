using System;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR

#endif

public class OnPhysicsTrigger : MonoBehaviour
{
    public string ListenerTag;
    public OnEnterCollision onEnterCollision = new OnEnterCollision();
    public OnEnterTrigger onEnterTrigger = new OnEnterTrigger();
    public OnExitCollision onExitCollision = new OnExitCollision();
    public OnExitTrigger onExitTrigger = new OnExitTrigger();

    public OnStart onStart = new OnStart();


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
            onEnterCollision.Invoke(collision.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ListenerTag))
            onExitCollision.Invoke(collision.gameObject.tag);
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

    /*
#if UNITY_EDITOR
    [CustomEditor(typeof(OnPhysicsTrigger))]
    public class InspectorOnPhysicsTrigger : Editor
    {
        bool showinspector = false;
        
        public override void OnInspectorGUI()
        {
            if (showinspector)
                base.OnInspectorGUI();

            var mytarget = target as OnPhysicsTrigger;
            if (GUILayout.Button("Do it"))
            {
                showinspector = !showinspector;
            }

        }
    }

#endif\
*/
}