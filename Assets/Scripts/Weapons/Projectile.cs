using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] [Range(1000, 25000f)] float _launchForce = 1000;
    [SerializeField] [Range(10f, 1000f)] int _damage = 100;
    [SerializeField] [Range(2f, 10f)] float _range = 2f;

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

    void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.collider.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            Vector3 hitPosition = collision.GetContact(0).point;
            damageable.TakeDamage(_damage, hitPosition);
        }
    }
}
