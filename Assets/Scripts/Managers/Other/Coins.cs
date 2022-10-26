using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Coin[] coins;
    public int total { get; private set; }

    void Start() {
        total = coins.Length;
    }

    public void Reset() {
        for (int i = 0; i < total; i++) {
            coins[i].transform.gameObject.SetActive(true);
        }
    }
}
