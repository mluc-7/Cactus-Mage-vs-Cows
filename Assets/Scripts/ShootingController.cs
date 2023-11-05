using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingController : MonoBehaviour
{
    public GameObject enemy;
    public float shootRange = 10f;
    public float fireRate = 1f; // Adjust the rate of fire as needed.
    public Transform firePoint;
    public GameObject bulletPrefab;
    public List<GameObject> enemiesInRange = new List<GameObject>();

    public Transform target;
    private float nextFireTime;

    private void Start()
    {
        FindNearestEnemy();
    }

    private void Update()
    {
        FindNearestEnemy();

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Remove(other.gameObject);
            if (target == other.transform)
            {
                target = null; // Reset target if the current target exits the trigger.
            }
        }
    }

    private void FindNearestEnemy()
    {
        GameObject closestObject = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject obj in enemiesInRange)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
                target = closestObject.transform;
            }
        }
    }

    private void Shoot()
    {
        Vector2 direction = target.transform.position - transform.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotDirection = Quaternion.Euler(0, 0, rotation);
        Instantiate(bulletPrefab, firePoint.position, rotDirection);

    }
}