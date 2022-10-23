using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputInterface input;
        if (collision.gameObject.TryGetComponent<InputInterface>(out input) 
            && collision.isTrigger == false) 
        {
            Debug.Log("FruitSec"); 
        }
    }
}
