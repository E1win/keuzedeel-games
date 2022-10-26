using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        string collidingTag = other.gameObject.tag;

        if (collidingTag == "Enemy") {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (collidingTag == "Ground") {
            Debug.Log("Ground");
            Destroy(gameObject);
        }
    }
}
