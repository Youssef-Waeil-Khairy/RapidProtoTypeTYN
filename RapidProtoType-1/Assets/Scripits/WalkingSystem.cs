using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingSystem : MonoBehaviour
{
    public Rigidbody rb;
    public InputAction wASD;

    public float speed = 2f;

    float MouseX;
    float MouseY;

    private Vector2 direction = Vector2.zero;

    private void OnEnable()
    {
        wASD.Enable();
    }

    private void OnDisable()
    {
        wASD.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        direction = wASD.ReadValue<Vector2>();

        //Camera Orientation
        MouseX += Input.GetAxis("Mouse X");
        MouseY += Input.GetAxis("Mouse Y");
        MouseY = Mathf.Clamp(MouseY, -45, 60);

        //Application
        transform.rotation = Quaternion.Euler(0, MouseX, 0);
        Camera.main.transform.rotation = Quaternion.Euler(-MouseY, MouseX, 0);
    }

    private void FixedUpdate()
    {
        
        Vector3 move = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);

        
        move = transform.TransformDirection(move);

        rb.velocity = move;
    }
}
