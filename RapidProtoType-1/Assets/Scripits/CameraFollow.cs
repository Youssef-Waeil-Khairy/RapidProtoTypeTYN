using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camHinge; 

    public float lLerp = 0.2f; 
    public float tLerp = 0.2f; 

    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, camHinge.position, lLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camHinge.rotation, tLerp);
    }
}
