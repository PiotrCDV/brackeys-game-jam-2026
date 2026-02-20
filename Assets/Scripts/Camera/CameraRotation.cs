using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationController : MonoBehaviour
{
    [Header("Sensitivity settings")]
    public float sensitivityX = 0.15f;
    public float sensitivityY = 0.15f;

    [Header("Camera vertical angle")]
    public float minVerticalAngle = -25f;
    public float maxVerticalAngle = 25f;

    [Header("Zoom settings")]
    public float zoomFOV = 30f;
    public float zoomSpeed = 10f;

    private InputSystem_Actions inputActions;
    private Camera cam;
    private float defaultFOV;
    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        cam = GetComponent<Camera>();
        defaultFOV = cam.fieldOfView;

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        rotationY = currentRotation.y;
        rotationX = currentRotation.x;

        if (rotationX > 180) rotationX -= 360f;
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleRotation();
        HandleZoom();
    }

    private void HandleRotation()
    {
        Vector2 lookInput = inputActions.Player.Look.ReadValue<Vector2>();

        rotationY += lookInput.x * sensitivityX;
        rotationX -= lookInput.y * sensitivityY;

        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    private void HandleZoom()
    {
        bool isZooming = inputActions.Player.Attack.IsPressed();
        float targetFOV = isZooming ? zoomFOV : defaultFOV;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }
}