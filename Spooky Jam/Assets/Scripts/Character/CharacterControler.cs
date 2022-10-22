using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float Speed = 1;
    [SerializeField, Range(0,1), Tooltip("0.05")] private float AccelerationPower = 0.05f;
    #endregion

    #region private
    private AccelerationType AccelerationCurrentMode = AccelerationType.None;
    private float AccelerationIndex = 0;
    private InputInterface input = null;
    private enum AccelerationType
    {
        AccelerationFinished,
        DecelerationFinished,
        None
    }
    private Vector3 Direction;
    #endregion

    private void Awake()
    {
        input = gameObject.GetComponent<InputInterface>();
    }
    private void FixedUpdate()
    {
        if (input.GetDirection() != Vector3.zero)
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
        Direction = Vector3.Lerp(Direction, input.GetDirection().normalized, AccelerationIndex);
        AccelerationCurrentMode = type;
    }
}
