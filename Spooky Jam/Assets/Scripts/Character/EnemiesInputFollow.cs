using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
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
            if(CurrentPlayer)Debug.Log((CurrentPlayer.transform.position - transform.position).magnitude + " " + IndexCorrection);
        }
        else
        {
            if (CurrentMode == ModeEnemy.Search)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    CurrentMode = ModeEnemy.Sleep;
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
    public Vector3 GetDirection()
    {
        return Direction;
    }
}
