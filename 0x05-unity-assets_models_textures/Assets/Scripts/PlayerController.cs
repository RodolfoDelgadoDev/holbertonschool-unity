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
    }
    private void FixedUpdate()
    {
        float vHorizontal = Input.GetAxis("Horizontal");
        float vVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(vHorizontal, 0, vVertical);
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
