using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    [SerializeField] private string groundString = "Ground";

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == groundString) {
            playerMovement.SetGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == groundString) {
            playerMovement.SetGrounded(false);
        }
    }
}
