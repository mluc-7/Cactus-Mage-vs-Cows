using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform gunTransform;
    public float shootingRange = 10f;
    public float shootingCooldown = 1f;
    public GameObject bulletPrefab;

    private Transform closestEnemy;
    private float lastShotTime;

    private void Update()
    {
        FindClosestEnemy();

        if (closestEnemy != null && Time.time - lastShotTime >= shootingCooldown)
        {
            ShootAtEnemy();
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = shootingRange;
        closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
    }

    void ShootAtEnemy()
    {
        if (gunTransform != null)
        {
            Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            lastShotTime = Time.time;
        }
    }
}
