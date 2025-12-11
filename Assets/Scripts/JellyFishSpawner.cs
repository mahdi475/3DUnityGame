using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class JellyFishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jellyfish;
    [SerializeField] private float delay = 2f;
    [SerializeField] private GameObject waypoint1;
    [SerializeField] private GameObject waypoint2;

    private Vector3 point1;
    private Vector3 point2;

    private void Start()
    {
        point1 = waypoint1.transform.position;
        point2 = waypoint2.transform.position;

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(jellyfish, new Vector3(Random.Range(point1.x, point2.x), transform.position.y, Random.Range(point1.z, point2.z)), Quaternion.identity);

        StartCoroutine(Spawner());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        point1 = waypoint1.transform.position;
        point2 = waypoint2.transform.position;
        Gizmos.DrawLine(point1, point2);
        Gizmos.DrawLine(new Vector3(point2.x, point2.y, point2.z), new Vector3(point2.x, point1.y, point1.z));
        Gizmos.DrawLine(new Vector3(point1.x, point1.y, point1.z), new Vector3(point1.x, point2.y, point2.z));
    }
}
