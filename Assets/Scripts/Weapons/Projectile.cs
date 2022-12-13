using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] [Range(5000f, 25000f)] float _launchForce = 5000f;
    [SerializeField] [Range(10f, 1000f)] int _damage = 100;
    [SerializeField] [Range(10f, 1000f)] float _range = 5f;

    Rigidbody _rigidbody;
    float _duration;


    bool OutOfFuel
    {
        get 
        {
            _duration -= Time.deltaTime;
            return _duration <= 0f;
        }
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.AddForce(_launchForce * transform.forward);
        _duration = _range;
    }

    private void Update()
    {
        if (OutOfFuel)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"projectile collided with {collision.collider.name}");
    }
}
