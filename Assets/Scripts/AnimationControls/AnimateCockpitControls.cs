using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{

    [SerializeField] Transform _joystick;
    [SerializeField] Vector3 _joystickRange = Vector3.zero;

    [SerializeField] List<Transform> _throttles;
    [SerializeField] float _throttleRanges = 35;

    [SerializeField] ShipMovementInput _movementInput;

    IMovementControls ControlInput => _movementInput.MovementControls;

    void Update()
    {
        _joystick.localRotation = Quaternion.Euler(
            ControlInput.PitchAmount * _joystickRange.x,
            ControlInput.YawAmount * _joystickRange.y,
            ControlInput.RollAmount * _joystickRange.z
        );

        Vector3 throttleRotation = _throttles[0].localRotation.eulerAngles;
        throttleRotation.x = ControlInput.ThrustAmount * _throttleRanges;

        foreach (Transform throttle in _throttles)
            throttle.localRotation = Quaternion.Euler(throttleRotation);
    }
}
