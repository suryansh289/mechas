using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(attributeandhealth))]
public class attributeandhealtheditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        attributeandhealth tar = (attributeandhealth)target;
        if (GUILayout.Button("generate"))
        {
            tar.Starta();
        }
    }
}
