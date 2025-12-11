using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientParticleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ambientParticles;
    [SerializeField] private bool isEnabled = false;

    BoxCollider triggerBox;

    private void Awake()
    {
        triggerBox = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        if (ambientParticles == null)
        {
            isEnabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isEnabled == false)
        {
            ambientParticles?.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ambientParticles?.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (triggerBox == null)
        {
            triggerBox = GetComponent<BoxCollider>();
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + triggerBox.center, triggerBox.size);
    }
}
