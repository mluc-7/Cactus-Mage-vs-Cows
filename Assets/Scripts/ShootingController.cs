using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject enemy;
    public float shootRange = 10f;
    public float fireRate = 1f; // Adjust the rate of fire as needed.
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Transform target;
    private float nextFireTime;

    private void Start()
    {
        FindNearestEnemy();
    }

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (target != null)
            {
                // Check if the target is within range.
                if (Vector2.Distance(transform.position, target.position) <= shootRange)
                {
                    // Fire at the target.
                    Shoot();
                    nextFireTime = Time.time + 1f / fireRate;
                }
                else
                {
                    // If the target is out of range, find a new nearest enemy.
                    FindNearestEnemy();
                }
            }
            else
            {
                // If there is no target, find a new nearest enemy.
                FindNearestEnemy();
            }
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Tag your enemy GameObjects as "Enemy."
        float closestDistance = float.MaxValue;
        GameObject nearestEnemy = null;

        foreach (GameObject e in enemies)
        {
            float distance = Vector2.Distance(transform.position, e.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = e;
            }
        }

        target = nearestEnemy != null ? nearestEnemy.transform : null;
    }

    private void Shoot()
    {
        Vector3 direction = target.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        Quaternion rotDirection = Quaternion.Euler(0, 0, rot);
        Instantiate(bulletPrefab, firePoint.position, rotDirection);

    }
}