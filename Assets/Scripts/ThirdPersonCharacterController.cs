using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float movementSpeed = 5f; // Variable for setting the player movementspeed 
    public float turnSpeed = 10f;   // Variable for setting the player turnspeed

    private Animator animator; // a reference to the Animator component of the character.
    private new Rigidbody rigidbody; // a  reference to the Rigidbody component of the character.

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");  // Gets the user's input on the horizontal axis (A and D keys or left and right arrow keys).
        float verticalInput = Input.GetAxisRaw("Vertical");      // Gets the user's input on the vertical axis (W and S keys or up and down arrow keys).

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized; // Creates a normalized Vector3 from the user's input. This will be used to determine the direction the character should move in.
        Vector3 velocity = movement * movementSpeed * Time.fixedDeltaTime;  // Calculates the character's velocity using the normalized movement vector, the movement speed, and the fixed time interval.

        if (movement != Vector3.zero) // Checks if the character is moving.
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;    // Calculates the target angle for the character's rotation using the movement vector's x and z components
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f); // Creates a Quaternion rotation from the target angle.
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime); // Rotates the character using a Slerp function, which creates a smooth rotation over time. The turn speed is used to determine how quickly the character should rotate.
        }

        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(velocity)); // Moves the character using the Rigidbody's MovePosition function. The TransformDirection function is used to convert the velocity vector from local space to world space.

        animator.SetFloat("MovementSpeed", movement.magnitude);  // Sets the Animator's MovementSpeed parameter to the magnitude of the movement vector. This will be used to trigger animations based on the character's movement speed.
    }
}
