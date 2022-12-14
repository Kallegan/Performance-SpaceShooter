using System;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{

    [SerializeField] private FracturedAsteroid _francturedAsteroidPrefab;
    [SerializeField] private Detonator _explosionPrefab;

    private Transform _transform;

    public void TakeDamage(int damage, Vector3 hitLocation)
    {
        FractureAsteroid(hitLocation);
    }

    private void FractureAsteroid(Vector3 hitLocation)
    {
        if(_francturedAsteroidPrefab != null)
        {
            Instantiate(_francturedAsteroidPrefab, transform.position, transform.rotation);
        }    

        if(_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}



