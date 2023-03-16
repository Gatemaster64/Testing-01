using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";

    [SerializeField] float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis(horizontalInput);
        float vertical = Input.GetAxis(verticalInput);

        // calculate the movement direction based on the input axes
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // get the current camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // project the camera vectors onto the x-z plane (i.e. ignore the y component)
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // calculate the final movement vector based on the camera and input axes
        Vector3 finalMoveDirection = cameraForward * vertical + cameraRight * horizontal;

        // apply the movement to the player using the character controller component
        GetComponent<CharacterController>().SimpleMove(finalMoveDirection * speed);
    }

  
}