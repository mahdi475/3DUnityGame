using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpboost : MonoBehaviour
{
    [SerializeField] float bounciness;
    [SerializeField] AudioClip bounce;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(bounce);
        GameObject bouncer = collision.gameObject;
        Rigidbody rb = bouncer.GetComponent<Rigidbody>();
        rb.velocity = (Vector3.up * bounciness);
    }
}
