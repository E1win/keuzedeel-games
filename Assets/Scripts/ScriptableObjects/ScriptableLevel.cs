using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableLevel", menuName = "keuzedeel-games/ScriptableLevel", order = 0)]
public class ScriptableLevel : ScriptableObject {
    public int index;
    public string sceneName;
    public float startTime;
    public float highscore;
    public float recentClearTime;
}