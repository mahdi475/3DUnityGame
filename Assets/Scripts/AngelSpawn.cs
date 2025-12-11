using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelSpawn : MonoBehaviour
{
    [SerializeField] GameObject angelPrefab;
    [SerializeField] GameObject playerPrefab;
    PlayerController playerController;

    private Vector2 oldDashForce;
    private bool isInRange = false;

    private void Start()
    {
        playerController = playerPrefab.GetComponent<PlayerController>();
        oldDashForce = playerController.dashForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            angelPrefab.SetActive(true);
            playerController.dashForce = new Vector2(45f, 17.5f);
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(BeforeGoOff());
    }

    IEnumerator BeforeGoOff()
    {
        isInRange = false;
        yield return new WaitForSeconds(1);
        if (isInRange) { yield return null; }
        else
        angelPrefab.SetActive(false);
        playerController.dashForce = oldDashForce;
    }
}
