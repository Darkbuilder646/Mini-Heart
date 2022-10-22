using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour , InputInterface
{
    private Vector3 Direction;
    private void Update()
    {
        Direction = Vector3.zero;
        Direction += Input.GetKey(KeyCode.Z) ? Vector3.up : Vector3.zero;
        Direction += Input.GetKey(KeyCode.Q) ? Vector3.left : Vector3.zero;
        Direction += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;
        Direction += Input.GetKey(KeyCode.S) ? Vector3.down : Vector3.zero;
    }
    public Vector3 GetDirection()
    {
        return Direction;
    }
}
