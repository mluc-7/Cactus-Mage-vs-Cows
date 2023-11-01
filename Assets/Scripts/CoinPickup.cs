using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using TMPro;

[CreateAssetMenu(menuName = "Pickups/Coins")]

public class CoinPickup : PickupEffect
{
    public int coinAmount = 10;
    public int coinsAcquired;

    [SerializeField] TMPro.TextMeshProUGUI coinText;

    //on pickup, increases the target's coinsAcqiored and updates the cointText
    public override void Apply(GameObject target)
    {
        coinsAcquired = target.GetComponent<Coins>().coinsAcquired;
        coinsAcquired += coinAmount;
        coinText = target.GetComponent<Coins>().coinText;
        coinText.text = "Coins: " + coinsAcquired.ToString();

    }
}
