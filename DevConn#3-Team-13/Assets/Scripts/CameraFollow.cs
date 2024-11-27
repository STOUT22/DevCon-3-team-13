using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target; // The target object the camera will follow

    [Header("Follow Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset relative to the target
    public float followSpeed = 5f; // Speed at which the camera follows the target
    public bool smoothFollow = true; // Smooth follow toggle

    [Header("Rotation Settings")]
    public bool rotateWithTarget = true; // Should the camera match the target's rotation?
    public float rotationSpeed = 5f; // Speed at which the camera rotates to match the target

    private void LateUpdate()
    {
        if (!target) return;

        // Smoothly follow the target's position
        Vector3 desiredPosition = target.position + offset;
        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = desiredPosition;
        }

        // Rotate with the target
        if (rotateWithTarget)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
