using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrike : MonoBehaviour
{
    [SerializeField] GameObject beforeStrike;
    [SerializeField] GameObject strike;
    [SerializeField] GameObject strikeSFX;
    [SerializeField] private float delay1 = 1f;
    [SerializeField] protected float delay2 = 1.5f;

    private void Start()
    {
        StartCoroutine(_ThunderStrike());
    }

    IEnumerator _ThunderStrike()
    {
        beforeStrike.SetActive(true);
        yield return new WaitForSeconds(delay1);
        beforeStrike.SetActive(false);
        strike.SetActive(true);
        strikeSFX.SetActive(true);
        yield return new WaitForSeconds(delay2);
        Destroy(gameObject);
    }
}
