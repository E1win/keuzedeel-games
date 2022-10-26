using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemies;

    public void Freeze() {
        for (int i = 0; i < enemies.Length; i++) {
            enemies[i].Freeze();
        }
    }

    public void UnFreeze() {
        for (int i = 0; i < enemies.Length; i++) {
            enemies[i].UnFreeze();
        }
    }

    public void Reset() {
        for (int i = 0; i < enemies.Length; i++) {
            enemies[i].gameObject.SetActive(true);
            
            enemies[i].MoveToSpawn();
            enemies[i].ResetFacingDirection();
        }
    }
}
