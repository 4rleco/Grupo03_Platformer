using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private int lifes = 3;
    [SerializeField] private ForceMode2D forceMode;
    [SerializeField] private GameObject spawnPoint;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private float maxPosY = 8;
    private float minPosY = -8;

    private Vector2 movement;

    public event Action<bool> OnGameOver;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (lifes <= 0)
            OnGameOver?.Invoke(true);

        Movement();

        if (transform.position.y < minPosY || transform.position.y > maxPosY)
        {
            transform.position = spawnPoint.transform.position;
        }
    }
    private void FixedUpdate()
    {
        rigidbody.AddForce(movement * force, forceMode);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Saw & Spikes"))
        {
            lifes--;
            transform.position = spawnPoint.transform.position;
        }

        if (collision.gameObject.CompareTag("EndPoint"))
            OnGameOver?.Invoke(true);
    }

    private void Movement()
    {
        movement = Vector2.zero;

        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
            movement.y++;
    }
}
