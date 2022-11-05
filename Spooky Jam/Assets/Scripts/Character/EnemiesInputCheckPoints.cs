using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CharacterControler))]
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
    private Vector3 StartScale;
    private bool ScaleComplete = true;

    private void Awake()
    {
        StartScale = transform.localScale;
        Timer = TimeSearch;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput p;
        if (collision.gameObject.TryGetComponent<PlayerInput>(out p))
        {
            CurrentPlayer = p.gameObject;
            CurrentMode = ModeEnemy.Chase;
            CurrentPlayer.GetComponent<Beat>().ChangeBeatMode(true);
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
            if (ScaleComplete)
            {
                transform.DOScale(StartScale * 1.07f, 2).OnComplete(() =>
                    transform.DOScale(StartScale, 2).OnComplete(() => ScaleComplete = true));
                ScaleComplete = false;
            }
        }
        else
        {
            if (ScaleComplete)
            {
                transform.DOScale(StartScale * 1.07f, 1).OnComplete(() => 
                    transform.DOScale(StartScale, 1).OnComplete(()=> ScaleComplete = true));
                ScaleComplete = false;
            }
            if (CurrentMode == ModeEnemy.Search)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    CurrentMode = ModeEnemy.Checkpoint;
                    Timer = TimeSearch;
                    CurrentPlayer.GetComponent<Beat>().ChangeBeatMode(false);
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
