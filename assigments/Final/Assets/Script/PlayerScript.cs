using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 10f;

    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move and rotate if there's input
        if (movement.magnitude > 0.1f)
        {
            // Adjust for the player's backward model orientation
            Vector3 adjustedMovement = new Vector3(-movement.x, movement.y, -movement.z); // Reverse direction

            // Calculate movement speed
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

            // Move the player
            transform.Translate(adjustedMovement * currentSpeed * Time.deltaTime, Space.World);

            // Smoothly rotate to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(adjustedMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}