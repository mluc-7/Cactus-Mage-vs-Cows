using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void EndGame()
    {
        //logs Gameover and opens the gameOverPanel
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
    }

}
