using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotation = 1f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngine);
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else audioSource.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(mainRotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-mainRotation);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
