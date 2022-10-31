using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Coin[] coins;
    public int totalCoins { get; private set; }
    public PowerupInvinsibility[] powerups;
    public int totalPowerups { get; private set; }
    public PowerupLifeUp[] lifeUps;
    public int totalLifeUps { get; private set; }

    void Start() {
        totalCoins = coins.Length;
        totalPowerups = powerups.Length;
        totalLifeUps = lifeUps.Length;
    }

    public void Reset() {
        for (int i = 0; i < totalCoins; i++) {
            coins[i].transform.gameObject.SetActive(true);
        }

        for (int i = 0; i < totalPowerups; i++) {
            powerups[i].transform.gameObject.SetActive(true);
        }

        for (int i = 0; i < totalLifeUps; i++) {
            lifeUps[i].transform.gameObject.SetActive(true);
        }
    }
}
