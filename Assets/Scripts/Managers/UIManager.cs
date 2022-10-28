using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UIManager : Singleton<UIManager>
{
    TextFormatter formatter;

    [Header("Start")]
    public GameObject panelStart;

    [Header("Play")]
    public GameObject panelPlay;

    public TMP_Text timer;
    public GameObject[] lives;
    public TMP_Text bullets;

    [Header("Pause")]
    public GameObject panelPause;

    [Header("Level Clear")]
    public GameObject panelLevelClear;

    public TMP_Text clearTime;
    public TMP_Text highscore;

    [Header("Game Over")]
    public GameObject panelGameOver;


    protected override void Awake() {
        GameManager.GameStateChanged += GameManagerOnGameStateChanged;
        formatter = GetComponent<TextFormatter>();

        base.Awake();
    }

    void OnDestroy() {
        GameManager.GameStateChanged -= GameManagerOnGameStateChanged;
    }

    void GameManagerOnGameStateChanged(GameState state) {
        if (state == GameState.LevelClear) {
            UpdateClearTimes();
        }

        ActivateOnCondition(panelStart, state == GameState.Start, nameof(panelStart));
        ActivateOnCondition(panelPlay, state == GameState.Play || state == GameState.Start, nameof(panelPlay));
        ActivateOnCondition(panelPause, state == GameState.Pause, nameof(panelPause));
        ActivateOnCondition(panelLevelClear, state == GameState.LevelClear, nameof(panelLevelClear));
        ActivateOnCondition(panelGameOver, state == GameState.GameOver, nameof(panelGameOver));
    }

    /**********************************/
    // UPDATE UI
    /**********************************/

    public void UpdateTimer(float time) {
        timer.text = formatter.FormatTime(time, 1);
    }

    public void UpdateLives(int numLives) {
        for (int i = 0; i < lives.Length; i++) {
            lives[i].SetActive(false);
        }

        for (int i = 0; i < numLives; i++) {
            lives[i].SetActive(true);
        }
    }

    public void UpdateBullets(int numBullets) {
        bullets.text = numBullets.ToString();
    }

    private void UpdateClearTimes() {
        clearTime.text = formatter.FormatTime(LevelManager.Instance.GetTime(), 2);
        highscore.text = formatter.FormatTime(LevelManager.Instance.GetLevelHighscore(), 2);
    }


    /**********************************/
    // OTHER
    /**********************************/

    void ActivateOnCondition(GameObject obj, bool condition, string name="GameObject") {
        if (obj != null) {
            obj.SetActive(condition);
        } else {
            Debug.LogError(name + " has not been assigned in the UI Manager");
        }
    }
}
