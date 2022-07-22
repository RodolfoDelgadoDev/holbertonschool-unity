using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            if (other.gameObject.transform.localScale.x > 0.4)
            {
                other.gameObject.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
                audioSource.Play();
            }
        }
    }
}
