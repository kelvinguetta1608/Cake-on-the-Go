using UnityEngine;

/// <summary>
/// Camera movement script for third-person games.
/// This Script should not be applied to the camera! It is attached to an empty object, and inside
/// it (as a child object) should be your game's MainCamera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("Enable to move the camera by holding the right mouse button. Does not work with joysticks.")]
    public bool clickToMoveCamera = false;

    [Tooltip("Enable zoom in/out when scrolling the mouse wheel. Does not work with joysticks.")]
    public bool canZoom = true;

    [Tooltip("The tag of the object the camera should follow.")]
    public string targetTag = "Player"; // Editable in the inspector

    [Space]
    [Tooltip("The higher it is, the faster the camera moves. It is recommended to increase this value for games that uses joystick.")]
    public float sensitivity = 5f;

    [Tooltip("Camera Y rotation limits. The X axis is the maximum it can go up and the Y axis is the maximum it can go down.")]
    public Vector2 cameraLimit = new Vector2(-45, 40);

    private float mouseX;
    private float mouseY;
    private float offsetDistanceY;

    private Transform target; // The object to follow

    void Start()
    {
        // Find the target based on the tag specified in the inspector
        GameObject targetObject = GameObject.FindWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogWarning($"No object found with tag '{targetTag}'. Camera will not follow any object.");
        }

        offsetDistanceY = transform.position.y;

        // Lock and hide cursor if the option isn't checked
        if (!clickToMoveCamera)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Only update position and rotation if a valid target exists
        if (target != null)
        {
            // Follow the target with an offset in Y
            transform.position = target.position + new Vector3(0, offsetDistanceY, 0);

            // Align the camera rotation with the target's orientation
            Vector3 forwardDirection = target.forward; // Direction the target is facing
            Quaternion targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);

            // Smoothly interpolate to avoid abrupt movements
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * sensitivity);

            // Adjust zoom when the mouse wheel moves
            if (canZoom && Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Camera.main.fieldOfView = Mathf.Clamp(
                    Camera.main.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * sensitivity * 2,
                    20, 60 // Zoom limits
                );
            }
        }
    }
}
