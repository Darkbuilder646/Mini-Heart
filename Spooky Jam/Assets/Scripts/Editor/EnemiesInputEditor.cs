using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (EnemiesInputCheckPoints))]
public class EnemiesInputEditor: Editor
{
    private void OnSceneGUI()
    {
        EnemiesInputCheckPoints script = (EnemiesInputCheckPoints) target;
        for(int i = 0; i <script.checkPoints.Count; i++)
        {
            script.checkPoints[i] = Handles.DoPositionHandle(script.checkPoints[i], Quaternion.identity);
        }
    }
}