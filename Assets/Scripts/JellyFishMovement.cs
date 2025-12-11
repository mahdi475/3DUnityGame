using UnityEngine;

public class JellyFishMovement : MonoBehaviour
{
    [SerializeField] private float minMovement = 1.4f;
    [SerializeField] private float maxMovement = 2.2f;
    [SerializeField] private float minScale = 0.1f;
    [SerializeField] private float maxScale = 0.4f;
    [SerializeField] private float maxHeightBeforeDying = 75f;

    [SerializeField] private float rotationSpeed = 10f;

    private float scale;
    private float movementSpeed;

    private void Start()
    {
        movementSpeed = Random.Range(minMovement, maxMovement);
        scale = Random.Range(minScale, maxScale);

        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += (Vector3.up * movementSpeed * Time.deltaTime);

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        if (transform.position.y >= maxHeightBeforeDying)
        {
            Destroy(gameObject);
        }
    }
}
