using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameManager.Instance.PlayerDeath();
        }
    }
}
