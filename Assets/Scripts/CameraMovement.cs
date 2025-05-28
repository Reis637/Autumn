using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Target & Follow")]
    public Transform target; // The object the camera follows
    public float followSpeed = 5f; // How fast the camera catches up

    [Header("Mouse Influence")]
    public float mouseSensitivity = 0.5f; // How much the mouse affects the camera
    public float maxMouseDistance = 3f; // Max distance the camera can deviate from the player

    [Header("Camera Distance")]
    public float cameraDistance = 10f; // How far back the camera stays

    private Camera cam;
    private Vector3 smoothVelocity;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance);
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);

        Vector3 targetToMouse = mouseWorldPos - target.position;
        targetToMouse.z = 0;

        if (targetToMouse.magnitude > maxMouseDistance)
        {
            targetToMouse = targetToMouse.normalized * maxMouseDistance;
        }

        Vector3 desiredPosition = target.position + (targetToMouse * mouseSensitivity);
        desiredPosition.z = target.position.z - cameraDistance;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref smoothVelocity,
            followSpeed * Time.deltaTime
        );
    }
}