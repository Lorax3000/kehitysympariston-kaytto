
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The object the camera follows
    public Transform target;

    // Camera settings
    public float distance = 6f;
    public float height = 2f;
    public float mouseSensitivity = 3f;
    public float smoothSpeed = 10f;

    // Camera rotation limits
    public float minVerticalAngle = -20f;
    public float maxVerticalAngle = 60f;

    // Rotation values
    private float mouseX;
    private float mouseY = 15f;

    void Start()
    {
        // Lock the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Read mouse movement
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Limit vertical camera rotation
        mouseY = Mathf.Clamp(
            mouseY,
            minVerticalAngle,
            maxVerticalAngle
        );

        // Calculate camera rotation
        Quaternion rotation = Quaternion.Euler(
            mouseY,
            mouseX,
            0f
        );

        // Calculate camera position
        Vector3 offset = rotation * new Vector3(
            0f,
            height,
            -distance
        );

        Vector3 desiredPosition = target.position + offset;

        // Smooth camera movement
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Make camera look at the target
        transform.LookAt(target.position);
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
