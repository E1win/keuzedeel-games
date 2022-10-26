using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 spawnPos;

    EnemyMovement enemyMovement;
    Rigidbody2D rb2D;

    void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();
        rb2D = GetComponent<Rigidbody2D>();

        spawnPos = transform.position;
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (player.IsInvinsible()) {
                gameObject.SetActive(false);
            } else {
                player.Kill();
            }
        }
    }

    /**************************/
    // EXTERNAL MANIPULATION OF ENEMY
    /**************************/

    public void Freeze() {
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnFreeze() {
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void MoveToSpawn() {
        transform.position = spawnPos;
    }

    public void ResetFacingDirection() {
        enemyMovement.ResetFacingDirection();
    }
}
