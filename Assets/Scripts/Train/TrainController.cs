using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrainController : MonoBehaviour
{
    #region Variables

    [Header("Travel target")]
    public Transform targetPoint;

    [Header("Movement settings")]
    public float speed = 5f;

    [Header("Brake settings")]
    public float maxBrakeTimeLimit = 3f;
    private float currentBrakeTimeLeft;

    [Header("UI")]
    public Image brakeTimeBar;

    private bool isBrakeButtonPressed = false;
    private bool hasReachedDestination = false;

    private InputSystem_Actions inputActions;

    #endregion

    #region Unity Methods

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }



    void OnEnable()
    {
        currentBrakeTimeLeft = maxBrakeTimeLimit;
        UpdateBrakeUI();
        inputActions.Player.Brake.started += OnBrakeStarted;
        inputActions.Player.Brake.canceled += OnBrakeCanceled;
        inputActions.Player.Enable();
        hasReachedDestination = false;
    }

    void OnDisable()
    {
        inputActions.Player.Brake.started -= OnBrakeStarted;
        inputActions.Player.Brake.canceled -= OnBrakeCanceled;
        inputActions.Player.Disable();
    }

    private void OnBrakeStarted(InputAction.CallbackContext context) => isBrakeButtonPressed = true;
    private void OnBrakeCanceled(InputAction.CallbackContext context) => isBrakeButtonPressed = false;

    void Update()
    {
        if (targetPoint == null || hasReachedDestination) return;

        if (CanBrake())
        {
            HandleBraking();
        }
        else
        {
            HandleMovement();
        }
    }

    #endregion

    #region Private Methods

    private bool CanBrake()
    {
        return isBrakeButtonPressed && currentBrakeTimeLeft > 0f;
    }

    private void HandleBraking()
    {
        currentBrakeTimeLeft -= Time.deltaTime;

        currentBrakeTimeLeft = Mathf.Max(currentBrakeTimeLeft, 0f);

        UpdateBrakeUI();
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        CheckDestination();
    }

    private void CheckDestination()
    {
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
        {
            hasReachedDestination = true;
            Debug.Log("Train arrived at point");
        }
    }

    private void UpdateBrakeUI()
    {
        if (brakeTimeBar != null)
        {
            brakeTimeBar.fillAmount = currentBrakeTimeLeft / maxBrakeTimeLimit;
        }
    }

    #endregion
}