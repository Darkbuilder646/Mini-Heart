using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInputCheckPoints : MonoBehaviour , InputInterface
{
    private enum ModeEnemy
    {
        Chase,
        Shearch,
        Checkpoint
    }
    [SerializeField] private List<Vector3> CheckPoints;
    [SerializeField] private float DistanceFinish = 0.2f;
    private int index;
    private Vector3 Direction;
    private bool OnChase = false;
    private GameObject CurrentPlayer;

    private void Awake()
    {
        for(int i = 0; i<CheckPoints.Count; i++)
        {
            CheckPoints[i] = transform.TransformPoint(CheckPoints[i]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput p;
        if (collision.gameObject.TryGetComponent<PlayerInput>(out p))
        {
            CurrentPlayer = p.gameObject;
            OnChase = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInput p;
        if (collision.gameObject.TryGetComponent<PlayerInput>(out p))
        {
            CurrentPlayer = p.gameObject;
            OnChase = false;
        }
    }
    private void Update()
    {
        if (!OnChase)
        {
            Direction = CheckPoints[index] - transform.position;
            float Distance = Direction.magnitude;
            index = Distance <= DistanceFinish ? index + 1 : index;
            index = index > CheckPoints.Count - 1 ? 0 : index;
        }
        else
        {
            Direction = CurrentPlayer.transform.position - transform.position;
        }
        
    }
    public List<Vector3> checkPoints { get => CheckPoints; set => CheckPoints = value; }

    public Vector3 GetDirection()
    {
        return Direction;
    }
}
