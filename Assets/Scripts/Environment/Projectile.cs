using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 5f;

    private float decayTime = 5f;
    private float decayCounter = 0f;

    Rigidbody2D rb2D;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();

        decayCounter = decayTime;
    }

    void Update() {
        Decay();
    }

    void FixedUpdate() {
        rb2D.AddForce(-transform.right * _speed, ForceMode2D.Impulse);
    }

    public void Init(float inputSpeed, float inputRotation) {
        _speed = inputSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, inputRotation));
    }

    private void Decay() {
        decayCounter -= Time.deltaTime;

        if (decayCounter <= 0f) {
            Destroy(gameObject);
        }
    }
}
