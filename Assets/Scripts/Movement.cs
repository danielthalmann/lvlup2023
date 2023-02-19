using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float   horizontal;
    private float   speed = 8f;
    private float   jumpingPower = 16f;
    private bool    isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && rb.tag == "Bon")
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        Flip();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") && collision.collider is CapsuleCollider2D)
        {
            // Do something when a collision with an enemy's BoxCollider2D occurs
            Debug.Log("Ennemie toucher, restart du level... [Movement->OnCollisionEnter2D]");
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}