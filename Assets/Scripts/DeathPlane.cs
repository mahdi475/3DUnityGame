using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    PlayerCheckpoint checkpoint;
    GameMaster gm;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        checkpoint = GetComponent<PlayerCheckpoint>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = gm.lastCheckpointPos;
        }
    }
}
