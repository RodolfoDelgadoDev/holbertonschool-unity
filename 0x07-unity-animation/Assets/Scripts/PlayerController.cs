using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (canjump == true && Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("jumping", true);
            rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            canjump = false;
        }
        if (movementDirection != Vector3.zero)
        {
            ani.SetBool("moving", true);
        }
        else
        {
            ani.SetBool("moving", false);
        }
        /// Define de movement of the player
        float vHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(0, 0, 0);
        if (Input.GetAxis("Vertical") > 0)
        {
            move += transform.forward;
        }
        if (Input.GetAxis("Vertical") < 0)
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
        move.Normalize();

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
            canjump = true;
        }
        if (other.tag == "Void")
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 21, -2);
        }
    }
}
