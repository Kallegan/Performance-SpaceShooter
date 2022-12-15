using UnityEngine;

public class ShieldExplosion : MonoBehaviour
{
    [SerializeField] Light _lightEffect;
    [SerializeField] ParticleSystem _shieldEffect;

    private void Update()
    {
        if (_lightEffect == null )
            return;

        if(_lightEffect.range > 0)
        {
            _lightEffect.range -= 5 * Time.deltaTime;
        }

        if(_lightEffect.intensity > 0)
        {
            _lightEffect.intensity -= 2 * Time.deltaTime;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
