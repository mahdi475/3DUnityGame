using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingPlatformSticker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 collisionNormal = collision.GetContact(0).normal;

            if (collisionNormal.y < -0.9f)
            {
                collision.gameObject.transform.parent = gameObject.transform;

                return;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
