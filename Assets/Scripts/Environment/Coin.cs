using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // Get playerattack script
            // Add 3 bullets to player

            gameObject.SetActive(false);
        }
    }
}
