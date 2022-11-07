using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 spawnPos;

    private PlayerPowerup playerPowerup;
    private PlayerAttack playerAttack;
    Rigidbody2D rb2D;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        playerPowerup = GetComponent<PlayerPowerup>();
        spawnPos = transform.position;
    }
    
    public void Freeze() {
        rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void UnFreeze() {
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void MoveToSpawn() {
        transform.position = spawnPos;
    }

    public void ResetBullets() {
        playerAttack.ResetBullets();
    }

    public void DisablePowerups() {
        playerPowerup.DisableInvinsibility();
    }

    public void Kill() {
        if (playerPowerup.isInvinsible) return;

        GameManager.Instance.PlayerDeath();
    }

    public bool IsInvinsible() {
        return playerPowerup.isInvinsible;
    }
}
