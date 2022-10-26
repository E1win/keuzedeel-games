using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime = 20f;

    public float time { get; private set; }
    bool isTiming = false;

    void Update() {
        if (isTiming) {
            time -= Time.deltaTime;

            // Update UI

            if (time <= 0f) {
                // Time is up.
                // Player dies and loses a life
            }
        }
    }

    public void Reset() {
        time = startTime;
        // Update UI
    }

    public void StartTiming() {
        isTiming = true;
    }

    public void Stop() {
        isTiming = false;
    }

    /****************************/
    // SETTERS
    /****************************/

    public void SetStartTime(float newStartTime) {
        startTime = newStartTime;
    }
}
