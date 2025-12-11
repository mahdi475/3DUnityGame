using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private GameMaster gm;
    LightIncreasingScript lightincreasingScript;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        lightincreasingScript = GetComponentInChildren<LightIncreasingScript>();
        gm.lastCheckpointPos = new Vector3(0, 10, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //lightincreasingScript.letThereBeLight = true;
            gm.lastCheckpointPos = transform.position;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

}
