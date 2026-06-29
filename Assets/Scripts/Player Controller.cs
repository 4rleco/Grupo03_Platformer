using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private ForceMode2D forceMode;
    [SerializeField] private GameObject spawnPoint;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private float maxPosY = 6;
    private float minPosY = -6;

    private Vector2 movement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movement();

       if(transform.position.y < minPosY || transform.position.y > maxPosY)
        {
            transform.position = spawnPoint.transform.position;
        }
    }
    private void FixedUpdate()
    {
        rigidbody.AddForce(movement * force, forceMode);
    }

    private void Movement()
    {
        movement = Vector2.zero;

        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
            movement.y++;
    }
}
