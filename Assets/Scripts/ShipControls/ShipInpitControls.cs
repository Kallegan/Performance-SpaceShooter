using UnityEngine;

public class ShipInpitControls : MonoBehaviour
{
    [SerializeField] ShipInputManager.InputType _inputType = ShipInputManager.InputType.PlayerDesktop;

    public IMovementControls MovementControls { get; private set; }
    public IWeaponControls WeaponControls { get; private set; }

    private void Start()
    {
        MovementControls = ShipInputManager.GetMovementControls(_inputType);
        WeaponControls = ShipInputManager.GetWeaponControls(_inputType);

    }

    private void OnDestroy()
    {
        MovementControls = null;
    }
}
