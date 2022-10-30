using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Counter")]
    [SerializeField] private float moveStunAfterWallJumpTime = 0.2f;
    [SerializeField] private float moveStunCounter;
    [SerializeField] private float onWallBeforeJumpTime = 0.1f;
    [SerializeField] private float onWallBeforeJumpCounter;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = 0.1f;
    [SerializeField] private float jumpBufferTimeCounter;

    [Header("Horizontal Movement")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpHeight;

    [SerializeField] private bool jumpPressed;

    [Header("Wall Jump")]
    [SerializeField] private float wallJumpLength = 30f;
    [SerializeField] private float wallJumpHeight = 40f;
    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing, isGrabbingPreviousValue;

    [Header("Other")]
    [SerializeField] private float maxVelocity = 20f;
    [SerializeField] private bool grounded;
    public LayerMask whatIsGround;

    private float moveHorizontal;

    Rigidbody2D rb2D;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Flip player based on direction pressed
        if (moveHorizontal > 0.1f) {
            transform.localScale = Vector3.one;
        } else if (moveHorizontal < -0.1f) {
            transform.localScale = new Vector3(-1f, 1, 1f);
        }

        if (Input.GetButtonDown("Jump")) jumpBufferTimeCounter = jumpBufferTime;

        jumpPressed = jumpBufferTimeCounter >= 0f;

        Jump();
        WallJump();

        canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, whatIsGround);

        jumpBufferTimeCounter -= Time.deltaTime;
        moveStunCounter -= Time.deltaTime;
        coyoteTimeCounter -= Time.deltaTime;
    }

    void FixedUpdate() {
        Run();
        LimitVelocity();
    }

    /****************************/
    // MOVEMENT
    /****************************/

    private void Run() {
        if (moveStunCounter <= 0f) {
            rb2D.AddForce(new Vector2(moveHorizontal * speed, 0f), ForceMode2D.Impulse);
        }
    }

    private void Jump() {
        // If player presses jumps while currently grounded or grounded very recently
        if (jumpPressed && (grounded || coyoteTimeCounter >= 0f)) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
            
            jumpBufferTimeCounter = -1f;
        }

        // When user lets go of jump button and player character is still moving upward
        // Half current y velocity for short jump
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0f) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }

    public void WallJump() {
        isGrabbingPreviousValue = isGrabbing;
        isGrabbing = false;

        if (canGrab && !grounded && moveHorizontal != 0) {
            isGrabbing = true;

            if (!isGrabbingPreviousValue) {
                onWallBeforeJumpCounter = onWallBeforeJumpTime;
            }

            onWallBeforeJumpCounter -= Time.deltaTime;
        }

        if (isGrabbing && !grounded && (Input.GetButton("Jump") || jumpPressed) && onWallBeforeJumpCounter <= 0) {
            rb2D.velocity = new Vector2(-moveHorizontal * wallJumpLength, wallJumpHeight);

            moveStunCounter = moveStunAfterWallJumpTime;
        }
    }

    void LimitVelocity() {
        if (Mathf.Abs(rb2D.velocity.x) > maxVelocity) {
            // Counteract existing velocity with reverse.
            rb2D.AddForce(new Vector2(-moveHorizontal * speed, 0f), ForceMode2D.Impulse);
        }
    }

    /****************************/
    // SETTERS
    /****************************/

    public void SetGrounded(bool value) {
        grounded = value;

        if (!grounded) coyoteTimeCounter = coyoteTime;
    }
}
