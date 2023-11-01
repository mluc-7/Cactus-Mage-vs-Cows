using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Xp")]

public class XpPickup : PickupEffect
{
    public int xpAmount = 400;
        public override void Apply(GameObject target)
    {
        target.GetComponent<Level>().xp += xpAmount; //adds xpAmount to target's xp
    }
}
