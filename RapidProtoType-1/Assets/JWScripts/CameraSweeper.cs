using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSweeper : MonoBehaviour
{
    [SerializeField] Transform pivotPoint;
    [SerializeField] float defaultPitch = 1.0f;
    [SerializeField] float sweepAngle = 60f;
    [SerializeField] float sweepSpeed = 6f;

    float currentAngle = 0f;
    bool sweepingClockwise = true;

    // Update is called once per frame
    void Update()
    {
        currentAngle += sweepSpeed * Time.deltaTime * (sweepingClockwise ? 1f : -1f);
        if (MathF.Abs(currentAngle) >= sweepAngle/2f)
        {
            sweepingClockwise = !sweepingClockwise;
        }

        pivotPoint.transform.localEulerAngles = new Vector3 (0f, currentAngle, defaultPitch);
    }
}
