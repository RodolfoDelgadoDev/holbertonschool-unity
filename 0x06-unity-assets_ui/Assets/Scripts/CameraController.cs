using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scripts that controls the camera
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// the min angle in Y that the mouse can move
    /// </summary>
    private const float Y_ANGLE_MIN = 0.0f;

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

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        invert = 1;
        Debug.Log(invert);
    }

    private void Update()
    {
        if (!isInverted)
        {
            invert = -1;
        }
        else
        {
            invert = 1;
        }
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y") * invert;

        /// Clamp the angle ofthe camera
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN,  Y_ANGLE_MAX);

    }
    private void LateUpdate()
    {
        if (isInverted == false)
        {
            invert = -1;
        }
        /// direction of the camera
        Vector3 dir = new Vector3(0, 0, -distance);

        /// rotation of the camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
