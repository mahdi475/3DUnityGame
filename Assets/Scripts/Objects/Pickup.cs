using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Pickup : MonoBehaviour
{
    [SerializeField] enum PickupType { Coins, Damage };

    [SerializeField] PickupType pickupType;
    [SerializeField] int value;
    [SerializeField] float knockback;


    [Header("Sound")]
    [SerializeField] AudioClip[] gainTime ;
    [SerializeField] AudioClip[] loseTime ;
    [SerializeField] private bool isAFuckingMine = false;

    [SerializeField] VisualEffect vfx;
    MeshRenderer meshRenderer;

    public bool canChange;
    private AudioSource audioSource;
    private bool destructionTime = false;
    private bool vfxTime = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (vfx != null)
        {
            vfx.Stop();
        }
        meshRenderer = GetComponent<MeshRenderer>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: Add the pickup to the player's inventory or activate its effects
            switch (pickupType)
            {
                case PickupType.Coins:
                    // Add the coin value to the player's score or inventory
                    audioSource.PlayOneShot(gainTime[Random.Range(0, gainTime.Length)]);
                    
                    break;
                case PickupType.Damage:
                    // Apply the damage to the player
                    audioSource.PlayOneShot(loseTime[Random.Range(0, loseTime.Length)]);
                    meshRenderer.enabled = false;
                    GameObject bouncer = other.gameObject;
                    Rigidbody rb = bouncer.GetComponent<Rigidbody>();
                    rb.velocity = (Vector3.up * knockback);

                    break;
            }
            // TODO: Destroy the pickup object

            destructionTime = true;
            //TODO VisibleThenNotVisible script bool canChange = false
        }
    }
    private void Update()
    {
        Explosion();
    }

    void Explosion()
    {
        if (!destructionTime)
            return;
        if (destructionTime)
        {
            if (vfx != null && vfxTime)
            {
                vfx.Play();
                vfxTime = false;
            }

            gameObject.GetComponent<Collider>().enabled = false;
            if (transform.localScale.x > 0 && !isAFuckingMine)
            {
                transform.localScale = new Vector3(transform.localScale.x - 1 * Time.deltaTime, transform.localScale.y - 1 * Time.deltaTime, transform.localScale.y - 1 * Time.deltaTime);
            }
            else if (!audioSource.isPlaying)
            {
                Destroy(gameObject, 1f);
            }
        }
    }
}