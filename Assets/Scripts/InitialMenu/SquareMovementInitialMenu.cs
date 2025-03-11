using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovementInitialMenu : MonoBehaviour
{
    public float speed = 2f; 
    public float jumpForce = 5f; 
    public float minX, maxX; 
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.gravityScale = 1f;

        InvokeRepeating(nameof(Jump), Random.Range(1f, 3f), Random.Range(1f, 3f));

        spriteRenderer.color = Random.ColorHSV(0, 1, 0.8f, 1f, 0.8f, 1f);
    }

    void Update()
    {
        float moveDirection = movingRight ? 1 : -1;
        rb.velocity = new Vector2(speed * moveDirection, rb.velocity.y);

        if (transform.position.x >= maxX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        else if (transform.position.x <= minX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
