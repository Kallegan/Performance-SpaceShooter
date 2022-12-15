using UnityEngine;

[CreateAssetMenu(fileName = "ShipData", menuName = "Space Shooter/Ship Data", order = 1)]
public class ShipDataSO : ScriptableObject
{
    [SerializeField] [Range(1000f, 10000f)]
    float _thrustForce = 7500f,
          _pitchForce = 6000f,
          _rollForce = 1000f,
          _yawForce = 2000f;

    [SerializeField]
    int _shieldStrength = 5000,
        _shieldRefreshRate = 100,
        _maxHealth = 1000,
        _blasterDamage = 100,
        _blasterProjectileLifetime = 2;

    public float ThrustForce => _thrustForce;
    public float PitchForce => _pitchForce;
    public float RollForce => _rollForce;
    public float YawForce => _yawForce;
    public float ShieldStrength => _shieldStrength;
    public float ShieldRefreshRate => _shieldRefreshRate;
    public float MaxHealth => _maxHealth;
    public float BlasterDamage => _blasterDamage;
    public float BlasterProjectileLifetime => _blasterProjectileLifetime;
}
