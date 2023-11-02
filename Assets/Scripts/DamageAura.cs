using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour
{
    [SerializeField] float attackAreaSize = 3f;

    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
        ApplyDamage(colliders);
    }

    public void ApplyDamage(Collider2D[] colliders) 
    {
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null) // Check if it hit an enemy
            {
                enemy.TakeDamage(1); // Deal 1 damage to the enemy
            }
        }
    }
}
