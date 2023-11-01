using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupEffect pickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the pickup collides with the player, destroy the gameObject and apply the effect to the colliding gameObject (the player)
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            pickupEffect.Apply(collision.gameObject);
        }
    }
}
