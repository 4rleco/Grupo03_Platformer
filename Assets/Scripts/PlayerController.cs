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
    [SerializeField] private bool canJump;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jump;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private Animator animator;

    private float maxPosY;
    private float minPosY;

    private Vector2 movement;

    public event Action<bool> OnGameOver;
    public event Action<bool> OnWinGame;

    private void Awake()
    {
        minPosY = -Camera.main.orthographicSize;

        transform.position = spawnPoint.transform.position;

        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (lifes <= 0)
            OnGameOver?.Invoke(true);

        Movement();

        if (transform.position.y < minPosY)
        {
            lifes--;
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

        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            animator.SetFloat("SpeedY", 0);
        }

        if (collision.gameObject.CompareTag("EndPoint"))
            OnWinGame?.Invoke(true);
    }

    private void Movement()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("SpeedX",1);
            movement.x = Input.GetAxis("Horizontal");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("SpeedX", 1);
            movement.x = Input.GetAxis("Horizontal");
        }
        else
        {
            animator.SetFloat("SpeedX", 0);
            movement.x = 0;
        }


        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            animator.SetFloat("SpeedY", 1);
            rigidbody.AddForce(new Vector2(0f, jumpForce));
            canJump = false;

            jump.Play();
        }
    }
}
