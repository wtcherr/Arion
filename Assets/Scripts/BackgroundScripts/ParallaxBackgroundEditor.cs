using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ParallaxBackground))]
public class ParallaxBackgroundEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ParallaxBackground myScript = (ParallaxBackground)target;
        if(GUILayout.Button("Reset Layers"))
        {
            myScript.resetLayers();
        }
    }
}