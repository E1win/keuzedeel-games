using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumperMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] private float jumpHeight = 25f;
    private bool grounded;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        Jump();
    }

    private void Jump() {
        if (grounded) {
            Debug.Log("Jump");
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }
    }


    /****************************/
    // SETTERS
    /****************************/

    public void SetGrounded(bool value) {
        grounded = value;
    }
}
