using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIncreasingScript : MonoBehaviour
{
    [SerializeField] public bool letThereBeLight = false;
    private Light light;
    private void Awake()
    {
        light = GetComponent<Light>();
    }
    private void Start()
    {
        light.GetComponent<Light>().intensity = 0.0f;
    }

    private void Update()
    {
        if (letThereBeLight)
        {
            if (light.intensity !< 14)
            {
                light.intensity += 2.25f * Time.deltaTime;
            }
        }
        else
        {
            if (light.intensity !> 0)
            {
                light.intensity -= 1.5f * Time.deltaTime;
            }
        }
    }


}
