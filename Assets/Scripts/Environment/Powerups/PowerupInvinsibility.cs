using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupInvinsibility : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerPowerup playerPowerup = other.gameObject.GetComponent<PlayerPowerup>();

            playerPowerup.EnableInvinsibility();

            gameObject.SetActive(false);
        }
    }
}
