using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupBar : MonoBehaviour
{
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    public void SetTimeLeft(float time, float totalTime) {
        slider.value = time / totalTime;
    }
}
