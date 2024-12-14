using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLocker : MonoBehaviour
{
    public Quaternion LockedRotation;
    // Start is called before the first frame update
    void Start()
    {
        LockedRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = LockedRotation;
    }
}
