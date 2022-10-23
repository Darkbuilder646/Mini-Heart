using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CharacterControler))]
public class EnemiesInputFollow : MonoBehaviour , InputInterface
{
    private enum ModeEnemy
    {
        Sleep,
        Chase,
        Search
    }
    [SerializeField] private float TimeSearch = 1;
    private Vector3 Direction;
    private ModeEnemy CurrentMode = ModeEnemy.Sleep;
    private GameObject CurrentPlayer;
    private float Timer;
    [SerializeField]private float IndexCorrection = 0.02f;
    private Vector3 StartPosition;
    private bool ScaleComplete = true;
    private Vector3 StartScale;
    private void Awake()
    {
        StartScale = transform.localScale;
        Timer = TimeSearch;
        StartPosition = transform.position;
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
        if (CurrentMode == ModeEnemy.Sleep)
        {
            Direction = CurrentPlayer!= null && (StartPosition - transform.position).magnitude >= IndexCorrection ? StartPosition - transform.position : Vector3.zero;
            if (ScaleComplete)
            {
                transform.DOScale(StartScale * 1.07f, 1).OnComplete(() =>
                    transform.DOScale(StartScale, 1).OnComplete(() => ScaleComplete = true));
                ScaleComplete = false;
            }
        }
        else
        {
            if (ScaleComplete)
            {
                transform.DOScale(StartScale * 1.07f, 1).OnComplete(() =>
                    transform.DOScale(StartScale, 1).OnComplete(() => ScaleComplete = true));
                ScaleComplete = false;
            }

            if (CurrentMode == ModeEnemy.Search)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    CurrentMode = ModeEnemy.Sleep;
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
    public Vector3 GetDirection()
    {
        return Direction;
    }
}
