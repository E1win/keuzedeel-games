using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public PowerupInvinsibility[] powerups;
    public int total { get; private set; }

    void Start() {
        total = powerups.Length;
    }

    public void Reset() {
        for (int i = 0; i < total; i++) {
            powerups[i].transform.gameObject.SetActive(true);
        }
    }
}
