using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFormatter : MonoBehaviour
{
    public string FormatTime(float time, int decimalPoints = 1) {
        float timeRounded = Mathf.Round(time*Mathf.Pow(10, decimalPoints))/Mathf.Pow(10, decimalPoints);

        string endOfString = "";
        if (timeRounded % 1 == 0) {
            endOfString = ".0";
        }

        endOfString += "s";

        return timeRounded.ToString() + endOfString;
    }
}
