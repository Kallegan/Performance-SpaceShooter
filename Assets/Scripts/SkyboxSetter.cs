using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Skybox))]  

public class SkyboxSetter : MonoBehaviour
{

    [SerializeField] List<Material> _skyboxMaterials;

    Skybox _skybox;

    private void Awake()
    {
        _skybox = GetComponent<Skybox>();
    }

    private void OnEnable()
    {
        ChangeSkybox(0);
    }

    private void ChangeSkybox(int skyboxIndex)
    {
        if(_skybox != null && skyboxIndex >= 0 && skyboxIndex <= _skyboxMaterials.Count)
        {
            _skybox.material = _skyboxMaterials[skyboxIndex];
        }
    }
}
