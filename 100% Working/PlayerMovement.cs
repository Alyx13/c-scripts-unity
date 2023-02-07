using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the movement of the player in a 2D platformer.
// It moves the player left and right and allows for a double jump.
// The player can only jump once in the air, and when on walls they slide but can jump off of them.
public class PlayerMovement : MonoBehaviour
{
    // Speed of horizontal movement
    public float speed = 10f;

    // Force applied when jumping
    public float jumpForce = 500f;

    // Reference to the player's Rigidbody2D component
    private Rigidbody2D rigidBody;

    // Flag indicating whether the player is on the ground
    private bool isGrounded;

    // Flag indicating whether the player is touching a wall
    private bool isTouchingWall;

    // Number of jumps left for the player
    private int jumpsLeft;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the reference to the player's Rigidbody2D component
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get the horizontal input from the player
        float horizontalInput = Input.GetAxis("Horizontal");

        // Set the player's velocity based on the horizontal input
        rigidBody.velocity = new Vector2(horizontalInput * speed, rigidBody.velocity.y);

        // If the player is on the ground, set the number of jumps left to 2
        if (isGrounded)
        {
            jumpsLeft = 2;
        }

        // Check if the player has any jumps left or is touching a wall
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsLeft > 0 || isTouchingWall))
        {
            // Apply the jump force to the player's Rigidbody2D component
            rigidBody.AddForce(new Vector2(0, jumpForce));

            // Decrement the number of jumps left
            jumpsLeft--;
        }
    }

    // Called when the player enters a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the ground, set the isGrounded flag to true
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        // If the player collides with a wall, set the isTouchingWall flag to true
        if (collision.gameObject.tag == "Wall")
        {
            isTouchingWall = true;
        }
    }

    // Called when the player exits a collision
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the player exits the collision with the ground, set the isGrounded flag to false
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        // If the player exits the collision with a wall, set the isTouchingWall flag to false
        if (collision.gameObject.tag == "Wall")
        {
            isTouchingWall = false;
        }
    }
}