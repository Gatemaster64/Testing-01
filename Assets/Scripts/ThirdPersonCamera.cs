using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 0.5f;

    private Vector3 smoothVelocity;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + Vector3.up * height - target.forward * distance;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothSpeed);
        transform.LookAt(target.position + Vector3.up * height);
    }
}
