using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private ForceMode2D forceMode;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private Vector2 movement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        rigidbody.AddForce(movement * force, forceMode);   
    }

    private void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
            movement.y++;
    }
}
