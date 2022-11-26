using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCamRotation : MonoBehaviour
{
    [SerializeField] Transform _target;




    //will match background after playre movement has been called.
    private void LateUpdate()
    {
        transform.rotation = _target.rotation;
    }
}
