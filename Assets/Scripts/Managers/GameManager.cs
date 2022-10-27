using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState State;
    public static Action<GameState> GameStateChanged;
    private GameState previousState;

    [SerializeField] private int playerLives = 3;
    static int currentPlayerLives = 0;

    void Start() {
        if (currentPlayerLives == 0) currentPlayerLives = playerLives;
        UpdateGameState(GameState.Start);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (State == GameState.Play) {
                UpdateGameState(GameState.Pause);
            } else if (State == GameState.Pause) {
                UpdateGameState(GameState.Play);
            }
        }

        if (State == GameState.Start && Input.GetAxisRaw("Horizontal") != 0) {
            UpdateGameState(GameState.Play);
        }

        // Button to reset, for testing purposes.
        if (Input.GetKeyDown(KeyCode.R)) {
            UpdateGameState(GameState.Start);
        }
    }

    public void UpdateGameState(GameState newState) {
        previousState = State;
        State = newState;

        Time.timeScale = 1;

        switch(newState) {
             case GameState.Start:
                HandleStart();
                break;
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Pause:
                HandlePause();
                break;
            case GameState.LevelClear:
                HandleLevelClear();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        Debug.Log("State Updated: ");
        Debug.Log(newState);

        GameStateChanged.Invoke(newState);
    }

    private void HandleStart() {
        LevelManager.Instance.ResetTimer();
        LevelManager.Instance.StopTimer();

        LevelManager.Instance.ResetCollectables();

        LevelManager.Instance.PlayerToSpawn();
        LevelManager.Instance.PlayerFreeze();
        LevelManager.Instance.PlayerResetBullets();
        LevelManager.Instance.PlayerDisablePowerups();

        LevelManager.Instance.EnemiesReset();
        LevelManager.Instance.EnemiesFreeze();

        UIManager.Instance.UpdateLives(currentPlayerLives);
    }
    private void HandlePlay() {
        LevelManager.Instance.StartTimer();

        LevelManager.Instance.PlayerUnFreeze();

        LevelManager.Instance.EnemiesUnFreeze();

    }
    private void HandlePause() {
        Time.timeScale = 0;
    }
    private void HandleLevelClear() {
        if (LevelManager.Instance.IsNewHighscore()) {
            LevelManager.Instance.UpdateLevelData();
        }

        Time.timeScale = 0;
    }
    private void HandleGameOver() {
        Time.timeScale = 0;
        currentPlayerLives = playerLives;
    }

    /***************************************/
    // OTHER
    /***************************************/

    public void PlayerDeath() {
        currentPlayerLives--;

        if (currentPlayerLives <= 0) {
            UpdateGameState(GameState.GameOver);
        } else {
            UpdateGameState(GameState.Start);
        }
    }
}

public enum GameState {
    Start,
    Play,
    Pause,
    LevelClear,
    GameOver,
}
