using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedAsteroid : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float _lifetimeDuration = 10f;

    private float _cleaupTime;

    bool ShouldCleanup
    {
        get
        {
            _cleaupTime -= Time.deltaTime;
            return _cleaupTime <= 0f;
        }
    }

    private void OnEnable()
    {
        _cleaupTime = _lifetimeDuration;
    }

    private void Update()
    {
        if(ShouldCleanup)
             AstroidCleanup();
    }

    void AstroidCleanup()
    {
        Destroy(gameObject);
    }
}
