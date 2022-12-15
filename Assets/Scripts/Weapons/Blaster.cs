using System;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] Projectile _projectilePrefab;
    [SerializeField] Transform _blasterMuzzle;

    [SerializeField] [Range(0f, 5f)] float _blasterCooldownTime = 0.25f;

    private IWeaponControls _weaponInput;

    float _cooldown;



    bool WeaponReady
    {
        get
        {
            _cooldown -= Time.deltaTime;
            return _cooldown <= 0f;
        }
    }


  


    void Update()
    {
        if (_weaponInput == null) return;

        if(WeaponReady && _weaponInput.PrimaryFired)
        {
            FireProjectile();
        }
    }


    void FireProjectile()
    {
        _cooldown = _blasterCooldownTime;
        Instantiate(_projectilePrefab, _blasterMuzzle.position, transform.rotation);
    }

    internal void Init(IWeaponControls weaponInput)
    {
        _weaponInput = weaponInput;
    }
}
