using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadLevelOne() {
        SceneManager.LoadScene("Level1");
    }

    public static void LoadNextLevel() {
        int levelIndex = LevelManager.Instance.GetLevelIndex() + 1;
        string sceneName = "Level" + levelIndex.ToString();

        SceneManager.LoadScene(sceneName);
    }

    public static void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadHowToPlay() {
        SceneManager.LoadScene("HowToPlay");
    }

    public void CloseApplication() {
        Application.Quit();
    }

    /***************************/
    // other button functionality that should be somewhere else
    // but it's easier to put it here
    /***************************/

    public static void ResumeGame() {
        GameManager.Instance.UpdateGameState(GameState.Play);
    }
}
