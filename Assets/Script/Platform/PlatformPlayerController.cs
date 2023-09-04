using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    public Transform groundCheck, groundCheckLeft, groundCheckRight, ceilingCheck;
    public LayerMask groundLayer;

    public float playerSpeed, playerJumpStrength, fallMultiplier, lowMultiplier;
    public bool isGround;

    public Rigidbody2D rb;

    public float groundCheckRadius = .1f;

    public bool canMove;


    private void Update()
    {
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * playerSpeed, rb.velocity.y);
        
            isGround = IsGrounded(groundCheck) || 
                       IsGrounded(groundCheckLeft) || 
                       IsGrounded(groundCheckRight);
        
            if (Input.GetButtonDown("Jump") && isGround)
            {
                rb.velocity = Vector2.up * playerJumpStrength;
            }
        }
       

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * 
                                         (fallMultiplier - 1) * Time.deltaTime);
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * 
                                         (lowMultiplier - 1) * Time.deltaTime);
        }

        

    }

    

    bool IsGrounded(Transform checkPoint)
    {
        return Physics2D.OverlapCircle(checkPoint.position, 
            groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckLeft.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckRight.position, groundCheckRadius);
        Gizmos.DrawWireSphere(ceilingCheck.position, groundCheckRadius);
    }
}
