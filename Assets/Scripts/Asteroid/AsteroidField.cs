using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    [SerializeField] [Range(100, 10000)] private int _asteroidCount;
    [SerializeField] [Range(500f, 5000)] private float _radius = 2500;
    [SerializeField] [Range(0.1f, 1f)] private float _maxScale = 0.5f;
    [SerializeField] List<GameObject> _asteroidPrefabs;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        SpawnAsteroids();
    }


    void SpawnAsteroids()
    {
        for (int i = 0; i < _asteroidCount; i++)
        {
            GameObject asteroid = Instantiate(_asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Count)], _transform.position, Quaternion.identity);
            float scale = Random.Range(30f, _maxScale);
            asteroid.transform.localScale = new Vector3(scale, scale, scale);
            asteroid.transform.position += Random.insideUnitSphere * _radius;
            asteroid.GetComponent<Rigidbody>()?.AddTorque(Random.insideUnitCircle * Random.Range(0f, 50f));
        }
    }

}