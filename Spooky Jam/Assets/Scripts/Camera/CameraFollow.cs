using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void Update()
    {
        Vector3 NewPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        transform.position = NewPosition;
    }
}
