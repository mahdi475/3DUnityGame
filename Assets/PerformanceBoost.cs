using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceBoost : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToDisable;
    [SerializeField] GameObject[] objectsToEnable;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].gameObject.SetActive(false);
        }

        for (int i = 0;i < objectsToEnable.Length;i++)
        {
            objectsToEnable[i].gameObject.SetActive(true);
        }
    }
}
