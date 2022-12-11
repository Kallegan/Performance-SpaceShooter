using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{

    [SerializeField] Transform _joystick;
    [SerializeField] Vector3 _joystickRange = Vector3.zero;

    [SerializeField] List<Transform> _throttles;
    [SerializeField] float _throttleRanges = 35;



    IMovementControls _movementControls;

    void Update()
    {
        if (_movementControls == null) return;

        _joystick.localRotation = Quaternion.Euler(
            _movementControls.PitchAmount * _joystickRange.x,
            _movementControls.YawAmount * _joystickRange.y,
            _movementControls.RollAmount * _joystickRange.z
        );

        Vector3 throttleRotation = _throttles[0].localRotation.eulerAngles;
        throttleRotation.x = _movementControls.ThrustAmount * _throttleRanges;

        foreach (Transform throttle in _throttles)
            throttle.localRotation = Quaternion.Euler(throttleRotation);
    }

    public void Init(IMovementControls movementControls)
    {
        _movementControls = movementControls;
    }
}
