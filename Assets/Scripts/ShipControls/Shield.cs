using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] [Range(0.25f, 1f)] private float _fadeOutTime = 0.5f;
    [SerializeField] private float _minIntensity = -10f, _maxIntensity = 0f;
    [SerializeField] private int _maxShieldStrength = 5000;
    [SerializeField] private GameObject _shieldDepletedEffect;

    private Renderer _renderer;
    private Color _baseColor;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private int _shieldStrength;


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _baseColor = _renderer.material.color;
        _shieldStrength = _maxShieldStrength;
    }

    public void TakeDamage(int damage, Vector3 hitLocation)
    {

        _shieldStrength -= damage;

        if(_shieldStrength <= 0)
        {
            DestroyShields();
            return;
        }
        StartCoroutine(FlashInFadeShields());
    }

    private void DestroyShields()
    {
        StopAllCoroutines();
        if(_shieldDepletedEffect != null)
        {
            Instantiate(_shieldDepletedEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    IEnumerator FlashInFadeShields()
    {
        Color shieldColor;
        Color emissionColor = _renderer.material.GetColor(EmissionColor);
        float currentTime = 0f;
        float intensity = _maxIntensity;

        while (currentTime < _fadeOutTime)
        {
            shieldColor = Color.Lerp(_flashColor, _baseColor, currentTime / _fadeOutTime);
            intensity = Mathf.Lerp(_maxIntensity, _minIntensity, currentTime / _fadeOutTime);
            ChangeShieldColor(shieldColor, emissionColor * Mathf.Pow(2, intensity));
            currentTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }

    private void ChangeShieldColor(Color shieldColor, Color emissionColor)
    {
        _renderer.material.color = shieldColor;
        _renderer.material.SetColor(EmissionColor, emissionColor);
    }
}
