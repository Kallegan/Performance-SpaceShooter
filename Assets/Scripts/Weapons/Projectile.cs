using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    [Range(5000f, 25000f)]
    float _launchForce = 10000f;

    Rigidbody _rigidbody;    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
