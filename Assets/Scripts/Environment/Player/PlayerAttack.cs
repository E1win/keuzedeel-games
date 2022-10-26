using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject projectilePrefab;

    [SerializeField] private float bulletSpeed = 5f;
    private int beginBullets = 3;
    [SerializeField] private int bullets;
    [SerializeField] private float shootingDelay = 0.2f;
    private float shootingDelayCounter;
    
    private Transform _transform;

    void Start() {
        if (cam == null) cam = Camera.main;
        _transform = transform;

        bullets = beginBullets;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && bullets > 0) {
            Shoot();
        }

        // shootingDelayCounter -= Time.deltaTime;
    }

    private void Shoot() {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - _transform.position).normalized;

        Projectile projectile = Instantiate(projectilePrefab, _transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.Init(bulletSpeed, AngleBetweenTwoPoints(_transform.position, mousePos));

        bullets--;
    }

    public void AddBullets(int num) {
        bullets += num;
    }

    public void ResetBullets() {
        bullets = beginBullets;
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
