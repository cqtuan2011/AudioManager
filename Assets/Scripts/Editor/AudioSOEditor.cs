using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioSO))]
public class AudioSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (AudioSO)target;

        DrawDefaultInspector();

        if (GUILayout.Button("SAVE"))
        {
            EditorUtility.SetDirty(script);
            Debug.Log("<color=yellow>SAVE AUDIO</color>");
        }
    }
}
