using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrainController : MonoBehaviour
{
    #region Variables

    [Header("Travel target")]
    public Transform targetPoint;

    [Header("Movement settings")]
    public float baseSpeed = 1.3f;
    public float speed = 1.3f;

    [Header("Brake settings")]
    public float maxBrakeTimeLimit = 3f;
    private float currentBrakeTimeLeft;

    [Header("UI")]
    public Image brakeTimeBar;

    private bool isBrakeButtonPressed = false;
    public bool hasReachedDestination = false; // mati ty cwelu czemu nie zrobiles tego od razu publicznym polem, a nie property z prywatnym setterem?

    private bool isSpeedButtonPressed = false;
    
    
    
    private InputSystem_Actions inputActions;

    #endregion

    #region Unity Methods

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }



    void OnEnable()
    {
        UpdateBrakeUI();
        inputActions.Player.Brake.started += OnBrakeStarted;
        inputActions.Player.Brake.canceled += OnBrakeCanceled;

        inputActions.Player.Speed.started += OnSpeedStarted;
        inputActions.Player.Speed.canceled += OnSpeedCanceled;

        inputActions.Player.Enable();
        hasReachedDestination = false;

        currentBrakeTimeLeft = maxBrakeTimeLimit;

        int level;
        try
        {
            level = GameMenager.Instance.GetDifficultyLevel();
        }
        catch (System.NullReferenceException)
        {
            level = 1;
        }

        if (level == 1 | level == 2 )
        {
            currentBrakeTimeLeft = 20f;
            maxBrakeTimeLimit = 20f;
        }
        
        if (level == 3 | level == 4)
        {
            currentBrakeTimeLeft = 30f;
            maxBrakeTimeLimit = 30f;
            
        }
        
        if (level == 5 | level == 6)
        {
            maxBrakeTimeLimit = 40f;
            currentBrakeTimeLeft = 40f;
        }
        
        if (level == 7 | level == 8)
        {
            currentBrakeTimeLeft = 50f;
            maxBrakeTimeLimit = 50f;
            
        }
        
        if (level == 9 | level == 10)
        {
            currentBrakeTimeLeft = 60f;
            maxBrakeTimeLimit = 60f;
            
        }

        if (level > 10)
        {
            currentBrakeTimeLeft = 70f;
            maxBrakeTimeLimit = 70f;
        }
        
        
        
    }

    void OnDisable()
    {
        inputActions.Player.Brake.started -= OnBrakeStarted;
        inputActions.Player.Brake.canceled -= OnBrakeCanceled;
        
        inputActions.Player.Speed.started -= OnSpeedStarted;
        inputActions.Player.Speed.canceled -= OnSpeedCanceled;
        
        inputActions.Player.Disable();
    }

    private void OnBrakeStarted(InputAction.CallbackContext context) => isBrakeButtonPressed = true;
    private void OnBrakeCanceled(InputAction.CallbackContext context) => isBrakeButtonPressed = false;

    void Update()
    {
        if (targetPoint == null || hasReachedDestination) return;

        HandleSpeed();
        
        if (CanBrake())
        {
            HandleBraking();
        }
        else
        {
            HandleMovement();
        }
    }

    private void HandleSpeed()
    {
        if (isSpeedButtonPressed)
        {
            speed = baseSpeed * 10f;
        }
        else
        {
            speed = baseSpeed;
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
            QuizMenager.Instance.StartQuiz();
            
            
        }
    }

    private void UpdateBrakeUI()
    {
        if (brakeTimeBar != null)
        {
            brakeTimeBar.fillAmount = currentBrakeTimeLeft / maxBrakeTimeLimit;
        }
    }
    
    private void OnSpeedStarted(InputAction.CallbackContext context) => isSpeedButtonPressed = true;
    private void OnSpeedCanceled(InputAction.CallbackContext context) => isSpeedButtonPressed = false;

    #endregion
}