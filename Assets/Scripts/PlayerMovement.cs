using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Rigidbody rb;

    Vector3 movementDirection;

    private void Start()
    {
        // Setting up the rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        CurrentInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CurrentInput()
    {
        // Gets current axis input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Moves the player based on input
        movementDirection = orientation.forward * horizontalInput + orientation.right * verticalInput;

        rb.AddForce(movementDirection.normalized * Time.deltaTime * 10f, ForceMode.Force);
    }
}
