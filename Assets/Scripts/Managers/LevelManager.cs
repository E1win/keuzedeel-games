using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : StaticInstance<LevelManager>
{

    public PlayerManager player;

    private float startTime;

    private EnemyManager enemies;
    private Timer timer;
    private Collectables collectables;
    private Level level;

    protected override void Awake() {
        enemies = GetComponent<EnemyManager>();
        timer = GetComponent<Timer>();
        collectables = GetComponent<Collectables>();
        level = GetComponent<Level>();

        startTime = level.GetStartTime();
        level.LoadData();

        base.Awake();
    }

    void Start() {
        Debug.Log("Start Called");
        if (level.GetIndex() == 1) {
            Debug.Log("Rest Player Lives");
            // If it's the first level, reset the player lives.

            GameManager.Instance.ResetPlayerLives();
        }
    }

    void Update() {
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

    public bool IsNewHighscore() {
        return level.IsNewHighscore(timer.time);
    }

    public void UpdateLevelData() {
        level.UpdateHighscore(timer.time);
        level.SaveData();
    }

    public int GetLevelIndex() {
        return level.GetIndex();
    }

    public float GetLevelHighscore() {
        return level.GetHighscore();
    }

    public void ResetCollectables() {
        collectables.Reset();
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
        timer.SetStartTime(startTime);
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
