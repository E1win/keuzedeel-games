using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpHeight;

    [Header("Other")]
    [SerializeField] private bool grounded;

    private float moveHorizontal;

    Rigidbody2D rb2D;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        Jump();
    }

    void FixedUpdate() {
        Run();
    }

    /****************************/
    // MOVEMENT
    /****************************/

    private void Run() {
        rb2D.AddForce(new Vector2(moveHorizontal * speed, 0f), ForceMode2D.Impulse);
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && grounded) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }

        // When user lets go of jump button and player character is still moving upward
        // Half current y velocity for short jump
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0f) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }

    /****************************/
    // SETTERS
    /****************************/

    public void SetGrounded(bool value) {
        grounded = value;
    }
}
