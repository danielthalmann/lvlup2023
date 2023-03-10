using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public bool canJump = false;
    public bool canAction = false;
    public bool canDestroy = false;
    public bool canShoot = false;
    public bool canMove = true;

    public Animator animator = null;

    public float   speed = 8f;
    public float jumpingPower = 16f;
    public Rigidbody2D rb;

    public float gravityScale = 10;
    public float fallGravityScale = 20;

    public GameObject bullet;
    public Transform throwPoint;

    protected float   horizontal;
    protected bool    isFacingRight = true;
    protected bool    jump = false;

    protected GameObject wall = null;
    protected GameObject interruptor = null;

    private void FixedUpdate()
    {
        if (animator != null)
        {
            if (horizontal != 0)
                StartWalk();
            else
                StopWalk();
        }
    }

    public void StartWalk()
    {
        if (animator != null)
        {
            animator.SetBool("walk", true);
        }

    }

    public void StopWalk()
    {
        if (animator != null)
        {
            animator.SetBool("walk", false);
        }

    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            // rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            //rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            transform.position = new Vector3(transform.position.x + ((speed * horizontal) * Time.deltaTime), transform.position.y, transform.position.z);
            Flip();
        }

        if (canJump)
        {
            // https://www.youtube.com/watch?v=c9kxUvCKhwQ

            if (Input.GetKeyDown(KeyCode.Space) && !jump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpingPower));
                jump = true;
            }

            if (rb.velocity.y > 0)
                rb.gravityScale = gravityScale;
            else
                rb.gravityScale = fallGravityScale;

            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        if (canAction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (interruptor != null)
                {
                    Interruptor inter = interruptor.GetComponent<Interruptor>();
                    inter.ToggleInterruptor();
                }
            }
        }

        if (canDestroy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (wall != null)
                {
                    Wall wl = wall.GetComponent<Wall>();
                    wl.openWall();
                }
            }
        }

        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interruptor")
        {
            interruptor = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interruptor")
        {
            interruptor = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jump = false;
        }
        
        if (collision.collider.tag == "Mur")
        {
            wall = collision.collider.gameObject;
        }

        if (collision.collider.tag == "Ennemi")
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Mur")
        {
            wall = null;
        }

    }

    protected void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void Shoot()
    {
        if (!bullet || !throwPoint)
            return;
        GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, Quaternion.Euler(Vector3.up));
        bulletClone.transform.localScale = transform.localScale;
        Destroy(bulletClone, 1f);
    }
}