using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpspeed;
    public bool canjump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canjump == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            canjump = false;
        }
        Rotation();
    }
    void Rotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
    private void FixedUpdate()
    {
        float vHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(0,0,0);
        if (Input.GetAxis("Vertical") > 0)
        {
            move += transform.forward;
            Debug.Log($"Arriba es {transform.forward}");

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            move += -transform.forward;
            Debug.Log($"Abajo es {-transform.forward}");

        }
        if (vHorizontal > 0)
        {
            move += transform.right;
            Debug.Log($"Derecha es {transform.right}");
        }
        if (vHorizontal < 0)
        {
            Debug.Log($"Izquierda es {-transform.right}");

            move += -transform.right;
        }
        move.Normalize();
        if (canjump == true)
        {
           move *= speed;
        }
        else
        {
            move *= speed / 4;
        }
        rb.AddForce(move);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            canjump = true;
        }
    }
}
