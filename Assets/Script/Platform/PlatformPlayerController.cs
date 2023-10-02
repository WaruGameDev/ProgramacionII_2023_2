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

    public float preBuffTime = .2f, actualPreBuffTime;
    public bool preBuff;

    public float coyoteTime = .2f, actualCoyoteTime;
    public bool coyoteJump;
    public bool jumping;
    
    public Rigidbody2D rb;

    public float groundCheckRadius = .1f;

    public bool canMove;
    public ParticleSystem dustJump;

    private void Start()
    {
        actualPreBuffTime = preBuffTime;
    }

    private void Update()
    {
        if (actualPreBuffTime < preBuffTime)
        {
            actualPreBuffTime += 1 * Time.deltaTime;
            preBuff = true;
            if (actualPreBuffTime >= preBuffTime)
            {
                preBuff = false;
            }
        }

        if (rb.velocity.y >0)
        {
            jumping = true;
        }

        if (isGround)
        {
            jumping = false;
            actualCoyoteTime = 0;
        }

        if (actualCoyoteTime < coyoteTime)
        {
            actualCoyoteTime += 1 * Time.deltaTime;
            coyoteJump = true;
            if (actualCoyoteTime >= coyoteTime)
            {
                coyoteJump = false;
                jumping = true;
            }
        }
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * playerSpeed, rb.velocity.y);
        
            isGround = IsGrounded(groundCheck) || 
                       IsGrounded(groundCheckLeft) || 
                       IsGrounded(groundCheckRight);
        
            if (Input.GetButtonDown("Jump"))
            {
                actualPreBuffTime = 0;
            }

            if (preBuff && (isGround||coyoteJump))
            {
                Jump();
            }
        }
       

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * 
                                         (fallMultiplier - 1) * Time.deltaTime);
            if (!jumping && !coyoteJump)
            {
                actualCoyoteTime = 0;
            }
               
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * 
                                         (lowMultiplier - 1) * Time.deltaTime);
        }
    }

    public void Jump()
    {
        dustJump.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * playerJumpStrength;
        jumping = true;
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
