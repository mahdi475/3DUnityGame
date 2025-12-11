using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MineTest : MonoBehaviour
{
    [SerializeField] VisualEffect explosionEffect;

    private void Awake()
    {
        explosionEffect.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            explosionEffect.Play();
        }
    }
}
