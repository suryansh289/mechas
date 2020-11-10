
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(attributeandhealthvfx))]
public class attributeandhealthvfxeditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        attributeandhealthvfx atvfx = (attributeandhealthvfx)target;
        if (GUILayout.Button("setattribute"))
        {
            atvfx.Starta();
        }
    }
}
