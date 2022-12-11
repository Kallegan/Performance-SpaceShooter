using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    enum VirtualCameras
    {
        NoCamera = -1,
        CockpitCamera = 0,
        FollowCamera
    }


    [SerializeField]
    List<GameObject> _virtualCameras;

    VirtualCameras CameraKeyPressed
    {
        get
        {
            for(int i=0; i < _virtualCameras.Count; i++)
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) return (VirtualCameras)i;    
            
                return VirtualCameras.NoCamera;
        }
    }

    void Start()
    {
        SetActiveCamera(VirtualCameras.CockpitCamera);
    }

    void Update()
    {
        SetActiveCamera(CameraKeyPressed);
    }

    private void SetActiveCamera(VirtualCameras activeCamera)
    {
        if (activeCamera == VirtualCameras.NoCamera)
        {
            Debug.Log("Missing Camera");
            return;
        }

        foreach(GameObject cam in _virtualCameras)        
            cam.SetActive(cam.tag.Equals(activeCamera.ToString()));
        
    }

}
