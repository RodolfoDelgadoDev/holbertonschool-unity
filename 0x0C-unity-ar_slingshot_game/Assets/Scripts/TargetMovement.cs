using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// TargetMovement class defines the movement of the targets.
/// </summary>
public class TargetMovement : MonoBehaviour
{

    private int vel;
    private Rigidbody rb;
    private int numb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vel = 8;
        numb = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        switch (numb)
        {
            case 0:
                rb.velocity = new Vector3(0, 0, vel) * Time.deltaTime;
                break;
            case 1:
                rb.velocity = new Vector3(vel, 0, 0) * Time.deltaTime;
                break;
            case 2:
                rb.velocity = new Vector3(0, 0, (-1) * vel) * Time.deltaTime;
                break;
            case 3:
                rb.velocity = new Vector3((-1) * vel, 0, 0) * Time.deltaTime;
                break;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "floor")
        {
            vel = vel * -1;
        }
    }

}
