using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool canJump = true;
    public float slideSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Vector2 wallNormal = collision.contacts[0].normal;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -wallNormal.y * slideSpeed);
        }
    }

}