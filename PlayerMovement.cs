using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collision;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask wallLayerMask;

    private Animator anim;
    private SpriteRenderer sprite;


    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float doubleJumpForce = 40f;
    [SerializeField] private float wallSlideSpeed = 1f;
    [SerializeField] private float wallDistance = 1f;


    private bool doubleJumpUsed;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool isJumping;
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collision.bounds.center, collision.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, run, jump, fall, doubleJump }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Check if player is touching wall
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right, wallDistance, wallLayerMask)
            || Physics2D.Raycast(transform.position, Vector2.left, wallDistance, wallLayerMask);

        // Check if player is wall sliding
        if (isTouchingWall)
        {
            isWallSliding = true;
            isJumping = true;
        }
        else
        {
            isWallSliding = false;
        }
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded())
        {
            doubleJumpUsed = false;
            isJumping = false;
        }

        if (isTouchingWall)
        {
            doubleJumpUsed = false;
        }
   
        // If player can jump and double jump:
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || !doubleJumpUsed)
            {
                if (IsGrounded() && !isJumping)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpSoundEffect.Play();
                    isJumping = true;
                }
                else if (!IsGrounded() && !isTouchingWall)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                    jumpSoundEffect.Play();
                    doubleJumpUsed = true;
                }
            }

        }
        if (rb.velocity.y == 0)
        {
            isJumping = false;
        }

        if (!isTouchingWall)
        {
            directionX = Input.GetAxisRaw("Horizontal"); //Raw makes it reset to 0 immmediately.
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        }
        else
        {
            directionX = Input.GetAxisRaw("Horizontal"); //Raw makes it reset to 0 immmediately.
            rb.velocity = new Vector2(directionX * moveSpeed, -wallSlideSpeed);
        }


        UpdateAnimationState();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if collision is with a wall and player is moving towards it
        if (other.gameObject.tag == "Wall" && Mathf.Sign(transform.localScale.x) == Mathf.Sign(other.transform.position.x - transform.position.x))
        {
            isTouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset wall jump flag when leaving wall
        if (other.gameObject.tag == "Wall")
        {
            isTouchingWall = false;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f && !isTouchingWall)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (directionX < 0f && !isTouchingWall)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            if (doubleJumpUsed)
            {
                state = MovementState.doubleJump;
            }
            else
            {
                state = MovementState.jump;
            }

        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

}



