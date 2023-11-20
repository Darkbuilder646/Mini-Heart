using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public event System.Action<Transform> changeSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput>())
        {
            changeSpawn.Invoke(transform);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    
}
