using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour

{
    public float movementSpeed = 5.0f; //can change speed n sensitivity in inspector
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private bool isGrounded;
    private float verticalRotation = 0;
    public float jumpForce = 8.0f;
    public float gravity = -0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock cursor for better first-person experience
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1f);
        movementDirection *= movementSpeed;

        // Apply movement to the rigidbody
        rb.velocity = new Vector3(movementDirection.x, rb.velocity.y, movementDirection.z);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Lock cursor when escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Apply gravity manually
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);

  
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}