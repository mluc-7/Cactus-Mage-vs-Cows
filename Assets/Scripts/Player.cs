using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerCurrentHp;
    public int playerMaxHp = 1000;
    public float hpRegen = 1f;
    public float hpRegenTimer;

    [SerializeField] HpBar hpBar;
    public GameObject gameManager;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;

    void Awake()
    {
        playerCurrentHp = playerMaxHp;
        if (level == null)
        {
            level = GetComponent<Level>();
        }
        if (coins == null)
        {
            coins = GetComponent<Coins>();
        }
        
    }

    //update hp bar on start
    private void Start()
    {
        hpBar.ChangeHpBar(playerCurrentHp, playerMaxHp);
    }

    private void Update()
    {
        hpBar.ChangeHpBar(playerCurrentHp, playerMaxHp);//update the hp bar every frame
        hpRegenTimer += Time.deltaTime * hpRegen; //implement passive hp regen
        if (hpRegenTimer > 1f)
        {
            Heal(1);
            hpRegenTimer -= 1f;
        }
    }

    //function for the player to take damage
    public void TakeDamage(int damage)
    {
        if(isDead)
        {
            return;
        }
      
        playerCurrentHp -= damage;

        if(playerCurrentHp <= 0)
        {
            gameManager.GetComponent<GameOver>().EndGame();
            isDead = true;
        }
        hpBar.ChangeHpBar(playerCurrentHp, playerMaxHp);
    }

    
    public void Heal(int amount)
    {
        if (playerCurrentHp <= 0)  //if the player is not dead and the heal function is called, heal the player
        { 
            return; 
        }

        playerCurrentHp += amount;
        if (playerCurrentHp > playerMaxHp) //if the heal amount makes the player's hp go above the maxHp, set it to the maxHp
        {
            playerCurrentHp = playerMaxHp;
        }
        hpBar.ChangeHpBar(playerCurrentHp, playerMaxHp); //update the player's hpBar
    }
    
}
