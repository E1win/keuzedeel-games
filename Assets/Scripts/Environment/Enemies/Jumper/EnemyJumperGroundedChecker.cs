using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumperGroundedChecker : MonoBehaviour
{
    [SerializeField] private string groundString = "Ground";

    private EnemyJumperMovement enemyJumperMovement;

    void Start()
    {
        enemyJumperMovement = GetComponentInParent<EnemyJumperMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == groundString) {
            enemyJumperMovement.SetGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == groundString) {
            enemyJumperMovement.SetGrounded(false);
        }
    }
}
