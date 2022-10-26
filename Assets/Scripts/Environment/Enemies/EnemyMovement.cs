using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    public Transform castPos;

    [SerializeField] private float baseCastDist = 0.5f;
    
    [SerializeField] private bool startsFacingRight = true;

    string facingDirection;
    Vector3 baseScale;

    [SerializeField] private float _speed = 2.5f;

    Rigidbody2D rb2D;

    void Awake() {
        baseScale = transform.localScale;
        facingDirection = startsFacingRight ? RIGHT : LEFT;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(facingDirection == RIGHT ? _speed : -_speed, rb2D.velocity.y);

        if (IsHittingWall() || IsNearEdge()) {
            ToggleFacingDirection();
        }
    }

    void ToggleFacingDirection() {
        Vector3 newScale = baseScale;

        if (facingDirection == LEFT) {
            newScale.x = baseScale.x;

            facingDirection = RIGHT;
        } else {
            newScale.x = -baseScale.x;

            facingDirection = LEFT;
        }

        transform.localScale = newScale;
    }

    bool IsHittingWall() {
        float castDist = baseCastDist;

        // If character is facing left, shoot cast left. Right is default.
        if (facingDirection == LEFT) {
            castDist = -baseCastDist;
        }

        // Determine target destination based on cast distance
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.blue);

        // Shoot line from begin to end at layer
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground"))) {
            return true;
        } else {
            return false;
        }
    }

    bool IsNearEdge() {
        float castDist = baseCastDist;

        // Determine target destination based on cast distance
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);

        // Shoot line from begin to end at layer
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground"))) {
            return false;
        } else {
            return true;
        }
    }

    public void ResetFacingDirection() {
        // If enemy started facing right and is currently not doing so, toggle the facing direction.
        if (startsFacingRight && facingDirection != RIGHT) {
            ToggleFacingDirection();
        }
    }
}
