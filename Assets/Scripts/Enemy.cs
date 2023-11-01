using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyCurrentHp; // current health of the enemy
    private Rigidbody2D rb;
    [SerializeField] GameObject targetGameobject;
    Player targetCharacter;

    [SerializeField] int enemyMaxHp = 3; // maximum health of the enemy
    [SerializeField] int damage = 2;
    [SerializeField] int xpDrop = 400;
    [SerializeField] float enemyMovespeed = 3f;

    Transform targetDestination;
    

    private void Awake()
    {
        //sanity check for enemy's rigidbody
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    //set target for the enemy to move towards

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }
    void Start()
    {
        enemyCurrentHp = enemyMaxHp; // set the initial health to max health
    }

    private void FixedUpdate() //moves the enemy towards the position of the player(which was the targetGameObject)
    {
        Vector3 moveDirection = (targetDestination.position - transform.position).normalized;
        rb.velocity = moveDirection * enemyMovespeed; //moves the enemy's rigidbody in the direction vector * their movespeed
    }

    //Attack the player if the enemy collides with the player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //sanity check to get targetCharacter
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Player>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        enemyCurrentHp -= damage; // reduce the current health by the damage dealt

        if (enemyCurrentHp <= 0)
        {
            EnemyDeath(); // if the enemy has no health left, call the Death function
        }
    }

    void EnemyDeath()
    {
        //drop xp
        targetGameobject.GetComponent<Level>().AddXp(xpDrop);
        //check if they drop items
        GetComponent<DropOnDestroy>().CheckDrop();
        Destroy(gameObject); // destroy the enemy game object
        
    }
}
