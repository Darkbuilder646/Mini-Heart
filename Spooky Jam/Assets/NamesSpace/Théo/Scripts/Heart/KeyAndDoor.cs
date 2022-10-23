using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAndDoor : MonoBehaviour
{
    [SerializeField] private bool asRedKey = false;
    [SerializeField] private bool asBlueKey = false;
    [SerializeField] private Image KeyRedImage;
    [SerializeField] private Image KeyBlueImage;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("RedKey")) 
        {
            KeyRedImage.canvas.enabled = true;
            Debug.Log("RedKey");
            asRedKey = true;
            
            
            Destroy(other.gameObject);
        }
        if(other.CompareTag("BlueKey"))
        {
            asBlueKey = true;
            KeyBlueImage.canvas.enabled = true;
            Destroy(other.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("RedDoor") && asRedKey)
        {
            asRedKey = false;
            KeyRedImage.canvas.enabled = false;
            Destroy(other.gameObject);

        }
        if(other.collider.CompareTag("BlueDoor") && asBlueKey)
        {
            asBlueKey = false;
            KeyBlueImage.canvas.enabled = false;
            Destroy(other.gameObject);

        }
    }

}
