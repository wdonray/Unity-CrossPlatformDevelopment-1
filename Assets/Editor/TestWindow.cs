
using UnityEngine;
using UnityEditor;


public class TestWindow : EditorWindow {
    [MenuItem("Tools/Test Window %#e")]
    private static void Init()
    {
        var w = (TestWindow)GetWindow(typeof(TestWindow));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Print"))
            Debug.Log("hello world");
    }
}
