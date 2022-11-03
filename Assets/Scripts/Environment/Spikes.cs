using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerManager player;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject.GetComponent<PlayerManager>();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            //PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (!player.IsInvinsible()) {
                player.Kill();
            }
        }
    }
}
