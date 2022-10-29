using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float timeBetweenMovements = 3f;
    [SerializeField] private float counter;

    private bool currentlyLeft = true;

    public Transform leftTransform;
    public Transform rightTransform;

    
    void Start() {
        transform.position = leftTransform.position;

        Time.timeScale = 1;
    }

    void Update()
    {
        if (counter <= 0) {
            if (currentlyLeft) {
                transform.position = rightTransform.position;
            } else {
                transform.position = leftTransform.position;
            }

            currentlyLeft = !currentlyLeft;

            counter = timeBetweenMovements;
        }

        counter -= Time.deltaTime;
    }
}
