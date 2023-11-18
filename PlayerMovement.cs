using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool IsGrounded;
    public Transform groundCheck;   //for jump

    public LayerMask groundLayer;   //for jump
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("walk", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walk", true);
            sprite.flipX = true;
        }
        else 
        {
            anim.SetBool("walk", false);
        }
    }
     private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    

}
