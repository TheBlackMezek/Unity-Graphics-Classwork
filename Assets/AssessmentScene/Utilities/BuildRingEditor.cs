using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildRingComponent))]
public class BuildRingEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BuildRingComponent script = (BuildRingComponent)target;
        if(GUILayout.Button("Build Ring"))
        {
            script.BuildRing();
        }
    }

}
