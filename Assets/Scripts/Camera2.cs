using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float cameraSpeed = 2f;
    public float cameraRotationSpeed = 5f;

    private float mouseX, mouseY;

    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * cameraRotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * cameraRotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);

        transform.position = playerTransform.position + rotation * cameraOffset;
        transform.LookAt(playerTransform.position);
    }
}
