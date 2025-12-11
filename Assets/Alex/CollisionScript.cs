using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] float objectDelay = 0.5f;
    [SerializeField] int damage = 20;
    [SerializeField] int points = 20;

    private Timer timerScript;
    private void Start()
    {
        timerScript = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider PickupCollider)
    {
        if (PickupCollider.CompareTag("PositivePickup"))
        {
            timerScript.currentTime += points;
        }


        if (PickupCollider.CompareTag("NegativePickup"))
        {
            timerScript.currentTime -= damage;
        }
    }

    IEnumerator TextForPickups()
    {
        yield return new WaitForSeconds(objectDelay);
    }



}


