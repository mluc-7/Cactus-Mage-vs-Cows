using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    //closes the program
    public void QuitApplication()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
