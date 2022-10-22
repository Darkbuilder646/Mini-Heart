using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInputCheckPoints : MonoBehaviour, InputInterface
{
    private enum ModeEnemy
    {
        Chase,
        Search,
        Checkpoint
    }
    [SerializeField] private List<Vector3> CheckPoints;
    [SerializeField] private float DistanceFinish = 0.2f;
    [SerializeField] private float TimeSearch = 1;
    private int index;
    private Vector3 Direction;
    private ModeEnemy CurrentMode = ModeEnemy.Checkpoint;
    private GameObject CurrentPlayer;
    private float Timer;

    private void Awake()
    {
        Timer = TimeSearch;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput p;
        if (collision.gameObject.TryGetComponent<PlayerInput>(out p))
        {
            CurrentPlayer = p.gameObject;
            CurrentMode = ModeEnemy.Chase;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInput p;
        if (collision.gameObject.TryGetComponent<PlayerInput>(out p))
        {
            CurrentPlayer = p.gameObject;
            CurrentMode = ModeEnemy.Search;
        }
    }
    private void Update()
    {
        if (CurrentMode == ModeEnemy.Checkpoint)
        {
            Direction = CheckPoints[index] - transform.position;
            float Distance = Direction.magnitude;
            index = Distance <= DistanceFinish ? index + 1 : index;
            index = index > CheckPoints.Count - 1 ? 0 : index;
        }
        else
        {
            if (CurrentMode == ModeEnemy.Search)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    CurrentMode = ModeEnemy.Checkpoint;
                    Timer = TimeSearch;
                }
            }
            else
            {
                Timer = TimeSearch;
            }
            Direction = CurrentPlayer.transform.position - transform.position;
        }

    }
    public List<Vector3> checkPoints { get => CheckPoints; set => CheckPoints = value; }

    public Vector3 GetDirection()
    {
        return Direction;
    }
}
