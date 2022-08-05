using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class that defines the player controller
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Rigibody of the player
    /// </summary>
    Rigidbody rb;

    public Animator ani;
    /// <summary>
    /// speed of the player
    /// </summary>
    public float speed;

    /// <summary>
    /// jump speed of the player
    /// </summary>
    public float jumpspeed;

    /// <summary>
    /// boolean that checks if the player can jump
    /// </summary>
    public bool canjump = true;


    [SerializeField] private MyInputs inputActions;

    Vector2 inputMove = Vector2.zero;

    private void Awake()
    {
        inputActions = new MyInputs();
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Jump.performed += OnJump;

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(inputMove.x, 0, inputMove.y);
        
        if (movementDirection != Vector3.zero)
        {
            ani.SetBool("moving", true);
        }
        else
        {
            ani.SetBool("moving", false);
        }
        /// Define de movement of the player
        float vHorizontal = inputMove.x;
        Vector3 move = new Vector3(0, 0, 0);
        if (inputMove.y > 0)
        {
            move += transform.forward;
        }
        if (inputMove.y < 0)
        {
            move += -transform.forward;
        }
        if (vHorizontal > 0)
        {
            move += transform.right;
        }
        if (vHorizontal < 0)
        {
            move += -transform.right;
        }

        ///Method that normalize de vector, diagonal velocity is the same as the horizontal and vertical
        //move.Normalize();

        ///player normal velocity
        if (canjump == true)
        {
            move *= speed;
        }
        /// reduced velocity of the player while is in the air
        else
        {
            move *= speed / 4;
        }
        /// Force of movement
        rb.AddForce(move);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            ani.SetBool("jumping", false);
            ani.SetBool("falling", false);
            canjump = true;

        }
        if (other.tag == "Void")
        {
            ani.SetBool("falling", true);
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 21, -2);
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        inputMove = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (!canjump)
            return;
        ani.SetBool("jumping", true);
        rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
        canjump = false;
    }
}
