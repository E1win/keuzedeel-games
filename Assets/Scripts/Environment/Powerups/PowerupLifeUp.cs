using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupLifeUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameManager.Instance.AddPlayerLife();

            gameObject.SetActive(false);
        }
    }
}
