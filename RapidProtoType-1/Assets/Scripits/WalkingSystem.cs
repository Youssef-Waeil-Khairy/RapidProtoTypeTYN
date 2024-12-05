using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingSystem : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerControl playerControl;

    public float speed = 2f;

    float MouseX;
    float MouseY;

    private Vector2 direction = Vector2.zero;

    public AudioSource walkingSound;

    private void OnEnable()
    {
        playerControl = new PlayerControl();
    }

    private void OnDisable()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        //Camera Orientation
        MouseX += Input.GetAxis("Mouse X");
        //MouseY += Input.GetAxis("Mouse Y");
        //MouseY = Mathf.Clamp(MouseY, -45, 60);

        //Application
        transform.rotation = Quaternion.Euler(0, MouseX, 0);

        /*
        if (direction.magnitude > 0) 
        {
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
            else
            {
                walkingSound.Stop();
            }

        }
        */
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);

        move = transform.TransformDirection(move);

        rb.velocity = move;
    }

    public void OnMove(InputValue inputValue)
    {
        direction = inputValue.Get<Vector2>();
    }
}
