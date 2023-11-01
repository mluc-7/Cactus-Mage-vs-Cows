using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f; // speed of the bullet
    public Rigidbody2D rb; // rigidbody of the bullet

    float ttl = 6f; //time to live - time bullet lasts before it is destroyed

    void Start()
    {
        // set the velocity of the bullet based on its forward direction
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the bullet has hit an enemy
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) //check if it hit an enemy
        {
            enemy.TakeDamage(1); // deal 1 damage to the enemy
        }
        
        // destroy the bullet on impact with any object
        Destroy(gameObject);
        
    }

    private void Update()
    {
        ttl -= Time.deltaTime;

        if (ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    

    
}
