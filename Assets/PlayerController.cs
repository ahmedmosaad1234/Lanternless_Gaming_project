using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // how fast the character moves
    public float jumpHeight; // how high the character jumps

    public KeyCode Spacebar; // jump key (set to Space in the Inspector)
    public KeyCode L; // left movement key (set to Left Arrow in the Inspector)
    public KeyCode R; // right movement key (set to Right Arrow in the Inspector)

    public Transform groundCheck; // invisible point at the player's feet
    public float groundCheckRadius; // size of the circle around the feet
    public LayerMask whatIsGround; // what counts as ground (set to the Ground layer)
    private bool grounded; // true if the character is standing on solid ground

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded) // When user presses the space button ONCE
        {
            Jump();
        }

        if (Input.GetKey(L)) // When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            // moves left along the x-axis without disrupting the jump

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R)) // When user presses the right arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            // moves right along the x-axis without disrupting the jump

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void FixedUpdate()
    {
        // checks if the groundCheck circle overlaps the ground's collider
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        // jumps vertically along the y-axis without disrupting horizontal movement
    }
}