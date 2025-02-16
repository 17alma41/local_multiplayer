using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class otherMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float acceleration = 5f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] ParticleSystem collisionParticles;


    ParticleSystem particles;
    Rigidbody2D rb;
    Vector2 direction;

    void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();

        ResetMovement();
    }
    private void Update()
    {
        transform.up = target.position - transform.position;
    }

    void FixedUpdate()
    {
        direction = (target.position - transform.position).normalized;
        rb.velocity += direction * acceleration * Time.fixedDeltaTime;

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

    }

    private void ResetMovement()
    {
        direction = new Vector2(Random.Range(-1f, 1f),
            Random.Range(-1f, 1f))
            .normalized * rb.velocity.magnitude;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 collisionPosition = transform.position;

        particles.Stop();

        collisionParticles.transform.position = collisionPosition;
        collisionParticles.Play();

        transform.position = Vector2.zero;
        ResetMovement();

        particles.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 collisionPosition = transform.position;

        particles.Stop();

        collisionParticles.transform.position = collisionPosition;
        collisionParticles.Play();

        transform.position = Vector2.zero;
        ResetMovement();

        particles.Play();
    }
}
