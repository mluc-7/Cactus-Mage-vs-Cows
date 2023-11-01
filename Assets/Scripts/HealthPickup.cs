using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Health")]

public class HealthPickup : PickupEffect
{
    public int healAmount = 4;
        public override void Apply(GameObject target)
    {
        int playerHp = target.GetComponent<Player>().playerCurrentHp; 
        playerHp += healAmount; //adds the healamount to the character's hp
        if (playerHp > target.GetComponent<Player>().playerMaxHp)
        {
            playerHp = target.GetComponent<Player>().playerMaxHp; //if the hp after heal is over maxHp, set it to maxHp
        }
    }
}
