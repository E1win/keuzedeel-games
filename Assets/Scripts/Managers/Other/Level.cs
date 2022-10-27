using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public ScriptableLevel scriptableLevel;

    public void LoadData() {
        string variablePrefix = scriptableLevel.sceneName;

        scriptableLevel.highscore = PlayerPrefs.GetFloat(variablePrefix + "Highscore", 0);
    }

    public void SaveData() {
        string variablePrefix = scriptableLevel.sceneName;

        PlayerPrefs.SetFloat(variablePrefix + "Highscore", scriptableLevel.highscore);
    }

    public bool IsNewHighscore(float time) {
        return scriptableLevel.highscore == 0f || scriptableLevel.highscore < time;
    }

    public void UpdateHighscore(float time) {
        scriptableLevel.highscore = time;

        Debug.Log("New Highscore");
        Debug.Log(scriptableLevel.highscore);
    }

    /*********************/
    // GETTERS
    /*********************/

    public int GetIndex() {
        return scriptableLevel.index;
    }

    public float GetStartTime() {
        return scriptableLevel.startTime;
    }

    public float GetHighscore() {
        return scriptableLevel.highscore;
    }
}
