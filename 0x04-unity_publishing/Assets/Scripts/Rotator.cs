using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary> Rotator class to rotate the coin</summary>
public class Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(45 * Time.deltaTime, 0, 0);
    }
}
