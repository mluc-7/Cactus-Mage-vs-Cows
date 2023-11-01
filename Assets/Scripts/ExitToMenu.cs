using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    //use scene manager to switch to the MainMenu scene
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
