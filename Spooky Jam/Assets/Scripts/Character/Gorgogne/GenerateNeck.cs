using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNeck : MonoBehaviour
{
    [SerializeField] private GameObject Head;
    [SerializeField] private LineRenderer Line;
    [SerializeField] private Vector3[] PointsSpline = new Vector3[4];
    [SerializeField] private AnimationCurve CurrentCurve;
    [SerializeField] private int SizeCurve;

    public Vector3[] pointsSpline { get => PointsSpline; set => PointsSpline = value; }

    private void Start()
    {
        Line.positionCount = SizeCurve;
    }
    private void Update()
    {
        PointsSpline[0] = transform.position;
        PointsSpline[3] = Head.transform.position;

        List<Vector3> points = new List<Vector3>();
        float t = 0;
        for (int i = 0; i < SizeCurve; i++)
        {
                Line.SetPosition(i ,ExtensionMethod.BezierCurve(PointsSpline[0],PointsSpline[1],PointsSpline[2],PointsSpline[3], t));
                t += 1f / (SizeCurve-1);
        }
    }
    public void AddNeck()
    {
        Line.positionCount = SizeCurve;
        PointsSpline[0] = transform.position;
        PointsSpline[3] = Head.transform.position;

        List<Vector3> points = new List<Vector3>();
        float t = 0;
        for (int i = 0; i < SizeCurve; i++)
        {
            Line.SetPosition(i, ExtensionMethod.BezierCurve(PointsSpline[0], PointsSpline[1], PointsSpline[2], PointsSpline[3], t));
            t += 1f / SizeCurve;
        }
    }
}
