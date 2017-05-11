using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

[CustomEditor(typeof(OnPhysicsTrigger))]
public class OnPhysicsTriggerEditor : Editor
{
    protected static bool showLine = true; //declare outside of function
    private AnimBool showFields;
    private GUIStyle style;
    public int _choice;
    public enum TriggerType
    {
        Start = 0,
        OnTriggerEnter2D = 1,
        OnTriggerEnter = 2,
        OnCollisionEnter2D = 3,
        OnCollisionEnter = 4
    }


    private void OnEnable()
    {
        showFields = new AnimBool(true) {speed = 35f};
        showFields.valueChanged.AddListener(Repaint);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //base.OnInspectorGUI();
        //EditorUtility.SetDirty(target);

        //style = new GUIStyle("HelpBox") { richText = true };

        //EditorGUILayout.Space();

        //var mytarget = target as OnPhysicsTrigger;

        //if(mytarget == null)
        //    return;

        //if (GUILayout.Button("Add Event"))
        //{
        //    _choice = EditorGUILayout.Popup(_choice, System.Enum.GetNames(typeof(TriggerType)));
        //}
        //SerializedProperty onCheck0 = serializedObject.FindProperty("onStart"); // <-- UnityEvent
        //SerializedProperty onCheck1 = serializedObject.FindProperty("onEnterTrigger"); // <-- UnityEvent
        //SerializedProperty onCheck2 = serializedObject.FindProperty("onExitTrigger"); // <-- UnityEvent
        //SerializedProperty onCheck3 = serializedObject.FindProperty("onEnterCollision"); // <-- UnityEvent
        //SerializedProperty onCheck4 = serializedObject.FindProperty("onExitCollision"); // <-- UnityEvent

        //EditorGUILayout.PropertyField(onCheck0);
        //EditorGUILayout.PropertyField(onCheck1);
        //EditorGUILayout.PropertyField(onCheck2);
        //EditorGUILayout.PropertyField(onCheck3);
        //EditorGUILayout.PropertyField(onCheck4);
    }
}
