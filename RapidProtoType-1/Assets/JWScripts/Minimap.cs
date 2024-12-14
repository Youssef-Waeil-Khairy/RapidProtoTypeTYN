using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 PlayerOffset = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position + PlayerOffset;
        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }
}
