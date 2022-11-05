using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void Start()
    {
        transform.position = GameObject.FindObjectOfType<CheckpointsManager>().currentSpawnPosition;
    }
}
