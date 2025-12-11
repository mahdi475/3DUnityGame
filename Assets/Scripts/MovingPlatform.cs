using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool willNotWaitForPlayer = false;
    private int currentWaypointsIndex = 0;
    private bool readyToGo = false;


    private void Start()
    {
        gameObject.transform.position = waypoints[currentWaypointsIndex];
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            readyToGo = true;
        }
    }

    void Movement()
    {
        if (readyToGo || willNotWaitForPlayer)
        {
            if (Vector2.Distance(waypoints[currentWaypointsIndex], transform.position) < .1f)
            {
                currentWaypointsIndex++;

                if (currentWaypointsIndex >= waypoints.Length)
                {
                    currentWaypointsIndex = 0;
                }
            }
            Vector3 currentWaypoint = waypoints[currentWaypointsIndex];
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Time.deltaTime * speed);
        }

    }

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawWireSphere(waypoints[i], .5f);
        }
    }
}
