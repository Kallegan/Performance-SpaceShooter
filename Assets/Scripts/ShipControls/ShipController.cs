using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    [SerializeField] ShipInpitControls _movementInput;

    [SerializeField] ShipDataSO _shipData;    

    [SerializeField] List<ShipEngine> _engines;
    [SerializeField] AnimateCockpitControls _CockpitControls;

    [SerializeField] List<Blaster> _blasters;


    Rigidbody _rigidBody;
    float _pitchAmount, _rollAmount, _yawAmount = 0f;

    IMovementControls MovementInput => _movementInput.MovementControls;
    IWeaponControls WeaponInput => _movementInput.WeaponControls;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        foreach (ShipEngine engine in _engines)
            
            engine.Init(MovementInput, _rigidBody, _shipData.ThrustForce / _engines.Count);

        foreach (Blaster blaster in _blasters)
            blaster.Init(WeaponInput);

        _CockpitControls.Init(MovementInput);
    } 

    private void Update()
    {             
        _rollAmount = MovementInput.RollAmount;
        _yawAmount = MovementInput.YawAmount;
        _pitchAmount = MovementInput.PitchAmount;
    }

    private void FixedUpdate()
    {
        if(!Mathf.Approximately(0f, _pitchAmount))        
            _rigidBody.AddTorque(transform.right * (_shipData.PitchForce * _pitchAmount * Time.fixedDeltaTime));

        if (!Mathf.Approximately(0f, _rollAmount))
            _rigidBody.AddTorque(transform.forward * (_shipData.RollForce * _rollAmount * Time.fixedDeltaTime));

        if (!Mathf.Approximately(0f, _yawAmount))
            _rigidBody.AddTorque(transform.up * (_shipData.YawForce * _yawAmount * Time.fixedDeltaTime));

    }
}
