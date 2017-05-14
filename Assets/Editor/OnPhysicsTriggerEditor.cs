using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;

namespace ChuTools
{
    [CustomEditor(typeof(CustomEventTrigger))]
    public class OnPhysicsTriggerEditor : EventTriggerEditor
    {
        protected static bool showLine = true; //declare outside of function


        public enum PhysicsTriggerType
        {
            Start = 0,
            OnTriggerEnter2D = 1,
            OnTriggerExit2D = 2,
            OnCollisionEnter2D = 3,
            OnCollisionExit2D = 4
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            EditorGUILayout.PropertyField(serializedObject.FindProperty("onStart"), true); // <-- UnityEvent
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onEnterTrigger"), true); // <-- UnityEvent
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onExitTrigger"), true); // <-- UnityEvent
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onEnterCollision"), true); // <-- UnityEvent
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onExitCollision"), true); // <-- UnityEvent
            serializedObject.ApplyModifiedProperties();
        }
    }
}