using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : StaticInstance<LevelManager>
{

    public PlayerManager player;

    private EnemyManager enemies;
    private Timer timer;
    private Coins coins;
    private Powerups powerups;

    protected override void Awake() {
        enemies = GetComponent<EnemyManager>();
        timer = GetComponent<Timer>();
        coins = GetComponent<Coins>();
        powerups = GetComponent<Powerups>();

        base.Awake();
    }

    void Update() {
        // check timer
        // if time is up
        if (timer.time <= 0f) {
            Debug.Log("Time is up!");
            UIManager.Instance.UpdateTimer(timer.time);
            GameManager.Instance.PlayerDeath();
        } else {
            UIManager.Instance.UpdateTimer(timer.time);
        }
    }

    /****************************/
    // LEVEL
    /****************************/

    public void ResetCollectables() {
        ResetCoins();
        ResetPowerups();
    }

    public void ResetCoins() {
        coins.Reset();
    }

    public void ResetPowerups() {
        powerups.Reset();
    }

    /****************************/
    // PLAYER
    /****************************/

    public void PlayerFreeze() {
        player.Freeze();
    }

    public void PlayerUnFreeze() {
        player.UnFreeze();
    }

    public void PlayerToSpawn() {
        player.MoveToSpawn();
    }

    public void PlayerResetBullets() {
        player.ResetBullets();
    }

    public void PlayerDisablePowerups() {
        player.DisablePowerups();
    }

    /****************************/
    // ENEMIES
    /****************************/

    public void EnemiesFreeze() {
        enemies.Freeze();
    }

    public void EnemiesUnFreeze() {
        enemies.UnFreeze();
    }

    public void EnemiesReset() {
        enemies.Reset();
    }

    /****************************/
    // TIMER
    /****************************/

    public void ResetTimer() {
        timer.Reset();
    }

    public void StartTimer() {
        timer.StartTiming();
    }

    public void StopTimer() {
        timer.Stop();
    }

    public float GetTime() {
        return timer.time;
    }
}
