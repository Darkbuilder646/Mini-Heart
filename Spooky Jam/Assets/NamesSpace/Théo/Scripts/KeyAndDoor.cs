using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndDoor : MonoBehaviour
{
    [SerializeField] private bool asRedKey = false;
    [SerializeField] private bool asBlueKey = false;
    public float vitesse = 0.5f;

    private void Update() 
    {
        if(Input.GetKey(KeyCode.Z))
            transform.position += Vector3.up * vitesse;

        if(Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * vitesse;
        
        if(Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * vitesse;

        if(Input.GetKey(KeyCode.Q))
            transform.position += Vector3.left * vitesse;


    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("RedKey")) 
        {
            asRedKey = true;
            Debug.Log("I have a Red Key");
            Destroy(other.gameObject);
        }
        if(other.CompareTag("BlueKey"))
        {
            asBlueKey = true;
            Debug.Log("I have a Blue Key");
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
