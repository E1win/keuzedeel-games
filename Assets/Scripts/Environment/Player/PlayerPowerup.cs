using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    public PowerupBar powerupBar;
    
    [SerializeField] private float invinsibilityTime = 5f;
    public bool isInvinsible {get; private set; }

    private Timer timer;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.SetStartTime(invinsibilityTime);
    }

    void Update()
    {
        if (!isInvinsible) return;

        if (timer.time <= 0f) {
            DisableInvinsibility();
        } else {
            powerupBar.SetTimeLeft(timer.time, invinsibilityTime);
        }
    }


    public void EnableInvinsibility() {
        isInvinsible = true;
        timer.Reset();
        timer.StartTiming();

        powerupBar.gameObject.SetActive(true);
    }

    public void DisableInvinsibility() {
        isInvinsible = false;
        
        powerupBar.gameObject.SetActive(false);
    }
}
