using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Scripts that controls the camera
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// the min angle in Y that the mouse can move
    /// </summary>
    private const float Y_ANGLE_MIN = 0.0f;


    public GameObject playerModel;
    /// <summary>
    /// The max angle in Y that the mouse can move
    /// </summary>
    private const float Y_ANGLE_MAX = 50.0f;

    /// <summary>
    /// Transform of the player
    /// </summary>
    public Transform lookAt;

    /// <summary>
    /// camera Transform
    /// </summary>
    public Transform camTransform;

    private Camera cam;

    /// <summary>
    /// Distance from the player to the camera
    /// </summary>
    private float distance = 10.0f;

    /// <summary>
    /// Movement of the mouse in X
    /// </summary>
    private float currentX = 0.0f;

    /// <summary>
    /// Movement of the mouse in Y
    /// </summary>
    private float currentY = 0.0f;

    public bool isInverted = false;
    private int invert;

    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    Vector2 inputLook = Vector2.zero;
    
    private MyInputs inputActions;
    private Vector2 inputDir;

    private void Awake()
    {
        inputActions = new MyInputs();
        inputActions.Enable();
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Move.performed += OnDir;
        inputActions.Player.Look.canceled += OnLook;
        inputActions.Player.Move.canceled += OnDir;


    }

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        invert = PlayerPrefs.GetInt("Inverted");
    }

    private void Update()
    {
        Vector3 movementDirection = new Vector3(inputDir.x, 0, inputDir.y);
        invert = PlayerPrefs.GetInt("Inverted");
        currentX += inputLook.x;
        currentY += inputLook.y * invert;

        /// Clamp the angle ofthe camera
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN,  Y_ANGLE_MAX);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, toRotation, 180f * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (isInverted == false)
        {
            invert = -1;
        }
        /// direction of the camera
        Vector3 dir = new Vector3(0, 2.5f, -6.25f);

        /// rotation of the camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        inputLook = value.ReadValue<Vector2>();
    }

    public void OnDir(InputAction.CallbackContext value)
    {
        inputDir = value.ReadValue<Vector2>();
    }
}
