using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int bulletsAdded = 3;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerAttack playerAttack = other.gameObject.GetComponent<PlayerAttack>();
            playerAttack.AddBullets(bulletsAdded);

            gameObject.SetActive(false);
        }
    }
}
