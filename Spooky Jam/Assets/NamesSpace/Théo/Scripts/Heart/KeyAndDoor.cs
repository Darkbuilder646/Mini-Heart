using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndDoor : MonoBehaviour
{
    [SerializeField] private bool asRedKey = false;
    [SerializeField] private bool asBlueKey = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("RedKey")) 
        {
            asRedKey = true;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("BlueKey"))
        {
            asBlueKey = true;
            Destroy(other.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("RedDoor") && asRedKey)
        {
            asRedKey = false;
            Debug.Log("Red Door Unlock");
            Destroy(other.gameObject);

        }
        if(other.collider.CompareTag("BlueDoor") && asBlueKey)
        {
            asBlueKey = false;
            Debug.Log("Blue Door Unlock");
            Destroy(other.gameObject);

        }
    }

}
