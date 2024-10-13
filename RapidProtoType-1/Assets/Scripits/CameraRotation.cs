using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Vector2 rotate;
    public float sens = 6f; 

    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotate.y += Input.GetAxis("Mouse Y") * sens; 
        rotate.x += Input.GetAxis("Mouse X") * sens; 

       
        rotate.y = Mathf.Clamp(rotate.y, -90f, 90f);

        
        transform.localRotation = Quaternion.Euler(-rotate.y, rotate.x, 0);
    }
}
