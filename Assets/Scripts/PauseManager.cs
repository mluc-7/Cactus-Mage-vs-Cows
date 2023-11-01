using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1f;//ensures game starts off unpaused
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;//freezes everything in game
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;//unfreeze on unpause
    }
}
