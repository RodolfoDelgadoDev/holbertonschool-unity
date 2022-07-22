using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private AudioSource audioSource;
    public Material[] materials;
    private float cycle;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cycle = 10;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, cycle, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            audioSource.Play();
            if (i == 5)
            {
                other.transform.GetComponent<Renderer>().material = materials[5];
                i = 0;
                GetComponent<Renderer>().material = materials[0];
            }
            else
            {
                other.transform.GetComponent<Renderer>().material = materials[i];
                i++;
                GetComponent<Renderer>().material = materials[i];
            }
        }
    }
}
