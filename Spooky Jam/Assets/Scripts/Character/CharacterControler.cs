using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float Speed = 1;
    [SerializeField] private PlayerInput playerInput = null;
    [SerializeField, Range(0,1), Tooltip("0.05")] private float AccelerationPower = 0.2f;
    #endregion

    #region private
    private AccelerationType AccelerationCurrentMode = AccelerationType.None;
    private float AccelerationIndex = 0;
    private enum AccelerationType
    {
        AccelerationFinished,
        DecelerationFinished,
        None
    }
    private Vector3 Direction;
    #endregion
    private void FixedUpdate()
    {
        if (playerInput.GetDirection() != Vector3.zero)
        {
            Acceleration(AccelerationType.AccelerationFinished);
        }
        else
        {
            Acceleration(AccelerationType.DecelerationFinished);
        }

        transform.position += Direction * Time.deltaTime * Speed;
    }

    private void Acceleration(AccelerationType type)
    {
        AccelerationIndex = AccelerationCurrentMode != type ? 0 : AccelerationIndex;
        AccelerationIndex = Mathf.Clamp(AccelerationIndex + AccelerationPower, 0, 1);
        Direction = Vector3.Lerp(Direction, playerInput.GetDirection().normalized, AccelerationIndex);
        AccelerationCurrentMode = type;
    }
}
