using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinsAcquired;
    public TMPro.TextMeshProUGUI coinText; //not good practice to couple gameplay logic with graphical interface

    public void AddCoins(int amount) //adds coin amount to player's acquired coins and prints it to the coinText
    {
        coinsAcquired += amount;
        coinText.text = "Coins: " + coinsAcquired.ToString();
    }
}
