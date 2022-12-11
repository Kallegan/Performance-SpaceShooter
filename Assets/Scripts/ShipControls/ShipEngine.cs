using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] GameObject _thruster;

    IMovementControls _shipMovementControls;
    Rigidbody _rigidbody;
    float _thrustForce;
    float _thrustAmount = 0f;

    bool bThurstersEnabled => !Mathf.Approximately(0f, _shipMovementControls.ThrustAmount);


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActivateThrusters();
    }

    private void FixedUpdate()
    {
        if (!bThurstersEnabled) return;

        _rigidbody.AddForce(transform.forward * (_thrustForce * Time.fixedDeltaTime));
    }

    private void ActivateThrusters()
    {
        _thruster.SetActive(bThurstersEnabled);
        if (!bThurstersEnabled) return;

        _thrustAmount = _thrustForce * _shipMovementControls.ThrustAmount;
    }

    public void Init(IMovementControls movementControls, Rigidbody rb, float thrustForce)
    {

        _rigidbody = rb;
        _shipMovementControls = movementControls;
        _thrustForce = thrustForce;
    }
}
