using System.Collections;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackTime;

    private Vector3 moveDirection;
    private Rigidbody playerrb;

    //private Rigidbody myRigidbody;
    private PlayerController playerScript;
    void Start()
    {
        playerScript = GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            playerrb = player.gameObject.GetComponent<Rigidbody>();
            playerrb.velocity = ((player.transform.position - transform.position).normalized) * knockbackForce; 
            //Knockback((player.transform.position - transform.position).normalized);
        }
    }

    public void Knockback(Vector3 direction)
    {
        moveDirection = direction * knockbackForce;
        StartCoroutine(Applyknockback());
    }

    IEnumerator Applyknockback()
    {
        float t = knockbackTime;

        while (t > 0) 
        { 
            t -= Time.deltaTime;
            playerrb.velocity = moveDirection;
            yield return new WaitForEndOfFrame();
        }

    }
}
