using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    [SerializeField] ShipInpitControls _movementInput;

    [SerializeField]
    [Range(1000f, 10000f)]
    float _thrustForce = 7500f,
          _pitchForce = 6000f,
          _rollForce = 1000f,
          _yawForce = 2000f;

    [SerializeField] List<ShipEngine> _engines;
    [SerializeField] AnimateCockpitControls _CockpitControls;


    Rigidbody _rigidBody;
    float _pitchAmount, _rollAmount, _yawAmount = 0f;

    IMovementControls ControlInput => _movementInput.MovementControls;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        foreach (ShipEngine engine in _engines)
            engine.Init(ControlInput, _rigidBody, _thrustForce / _engines.Count);

        _CockpitControls.Init(ControlInput);
    } 

    private void Update()
    {             
        _rollAmount = ControlInput.RollAmount;
        _yawAmount = ControlInput.YawAmount;
        _pitchAmount = ControlInput.PitchAmount;
    }

    private void FixedUpdate()
    {
        if(!Mathf.Approximately(0f, _pitchAmount))        
            _rigidBody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));

        if (!Mathf.Approximately(0f, _rollAmount))
            _rigidBody.AddTorque(transform.forward * (_rollForce * _rollAmount * Time.fixedDeltaTime));

        if (!Mathf.Approximately(0f, _yawAmount))
            _rigidBody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));

    }
}
