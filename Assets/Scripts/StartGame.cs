using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //use SceneManagement to transition to GameScene
    public void StartGameplay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
