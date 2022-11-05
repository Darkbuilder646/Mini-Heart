using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] private Checkpoint[] AllCheckpoints;
    private Vector2 CurrentSpawnPosition = Vector2.zero;
    public Vector2 currentSpawnPosition { get => CurrentSpawnPosition; set => CurrentSpawnPosition = value; }

    private void Start()
    {
        foreach(Checkpoint c in AllCheckpoints)
        {
            c.CheckPointSet += RegisterPosition;
        }
        
    }
    private void RegisterPosition(Transform t) 
    {
        CurrentSpawnPosition = new Vector2(t.position.x, t.position.y);
    }
}
