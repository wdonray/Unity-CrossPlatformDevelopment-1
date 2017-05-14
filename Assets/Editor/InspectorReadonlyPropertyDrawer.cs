using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(InspectorReadOnlyAttribute))]
public class InspectorReadonlyPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var attrib = attribute as InspectorReadOnlyAttribute;
        if (attrib != null)
        {
            var assignedpack = property.objectReferenceValue;
            if (assignedpack != null)
            {
                EditorGUI.LabelField(position, property.displayName, assignedpack.ToString());
            }
            
            
            
        }
        EditorGUI.EndProperty();
    }
}
