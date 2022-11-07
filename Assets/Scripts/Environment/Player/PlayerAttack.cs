using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject projectilePrefab;

    [SerializeField] private float bulletSpeed = 5f;
    private int beginBullets = 3;
    [SerializeField] private int bulletCount;
    
    private Transform _transform;

    void Start() {
        if (cam == null) cam = Camera.main;
        _transform = transform;

        bulletCount = beginBullets;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && bulletCount > 0 && GameManager.Instance.State == GameState.Play) {
            Shoot();
        }
    }

    private void Shoot() {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - _transform.position).normalized;

        Projectile projectile = Instantiate(projectilePrefab, _transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.Init(bulletSpeed, AngleBetweenTwoPoints(_transform.position, mousePos));

        bulletCount--;

        UIManager.Instance.UpdateBullets(bulletCount);
    }

    public void AddBullets(int num) {
        bulletCount += num;
        UIManager.Instance.UpdateBullets(bulletCount);
    }

    public void ResetBullets() {
        bulletCount = beginBullets;
        UIManager.Instance.UpdateBullets(bulletCount);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
