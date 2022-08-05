using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that handle the sounds of animations
/// </summary>
public class AnimationSounds : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// Array to save the clips to play
    /// </summary>
    [SerializeField] private AudioClip[] clips;

    private AudioSource audioSource;
    private Transform modelTransform;
    private bool recoverycheck = false;
    public GameObject landingsoundgameobject;

    private int i = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        modelTransform = GetComponent<Transform>();
    }

    private void Step()
    {
        AudioClip clip = clips[i];
        audioSource.PlayOneShot(clip);

    }
    
    private void Recovery()
    {
        recoverycheck = true;
    }
    private void ImpactSound()
    {
        AudioSource landingSound = landingsoundgameobject.GetComponent<AudioSource>();
        landingSound.PlayOneShot(landingSound.clip);
    }
    private void Update()
    {
        if (recoverycheck == true)
        {
            modelTransform.localPosition = new Vector3(0, modelTransform.localPosition.y, 0);
            recoverycheck = false;
        }
    }

}
