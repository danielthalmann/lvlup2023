using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontal;
    public float speed = 8f;
	public float jumpSpeed = 16f;
	public bool isRight = true;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform touchingGround;
	[SerializeField] private LayerMask Mask;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && isGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
		}
		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.5f);
        }
		flip();
    }


	private void flip()
	{
		if (isRight && horizontal < 0f || !isRight && horizontal > 0f)
		{
			isRight = !isRight;
			Vector3 LocalScale = transform.localScale;
			LocalScale.x *= -1f;
			transform.localScale = LocalScale;
		}
	}
	/// <summary>
	/// Check si le personnage est au sol
	/// </summary>
	/// <returns>1 si il est au sol</returns>
	private bool isGrounded()
	{
		return Physics2D.OverlapCircle(touchingGround.position, 0.2f, Mask);
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y * 0.5f);
	}
}
