using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (GenerateNeck))]
public class GenerateNeckEditor : Editor
{
    private int Iteration = 100;
    public override void OnInspectorGUI()
    {
        GenerateNeck script = (GenerateNeck)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Add Neck"))
        {
            script.AddNeck();
        }
    }
    private void OnSceneGUI()
    {
        GenerateNeck script = (GenerateNeck)target;
        for(int i = 0; i < script.pointsSpline.Length; i++)
        {
            script.pointsSpline[i] = script.transform.InverseTransformPoint(Handles.PositionHandle(script.transform.TransformPoint(script.pointsSpline[i]),Quaternion.identity));
        }
        List<Vector3> points = new List<Vector3>();
        float t = 0;
        for(int i = 1; i <Iteration; i++)
        {
            points.Add(ExtensionMethod.BezierCurve(script.transform.TransformPoint(script.pointsSpline[0]),
                script.transform.TransformPoint(script.pointsSpline[1]),
                script.transform.TransformPoint(script.pointsSpline[2]),
                script.transform.TransformPoint(script.pointsSpline[3]), t));
            t += 1f / Iteration;
        }

        Handles.DrawAAPolyLine(points.ToArray());
    }
}
