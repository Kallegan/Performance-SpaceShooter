using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    enum VirtualCameras
    {
        CockpitCamera,
        FollowCamera
    }


    [SerializeField]
    List<GameObject> _virtualCameras;

    void Start()
    {
        SetActiveCamera(VirtualCameras.CockpitCamera);
    }

    void Update()
    {

    }

    private void SetActiveCamera(VirtualCameras activeCamera)
    {
        foreach(GameObject cam in _virtualCameras)        
            cam.SetActive(cam.tag.Equals(activeCamera.ToString()));
        
    }

}
