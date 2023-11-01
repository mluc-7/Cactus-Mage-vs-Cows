using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    PauseManager pauseManager;
    void Awake()
    {
        if (pauseManager == null)
        {
            pauseManager = GetComponent<PauseManager>(); //can use GetComponent because pause manager is attached to the same component
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        { 
            if(menuPanel.activeInHierarchy == false) 
            { 
                OpenMenu();//if the escape key is pressed once and menuPanel is not active, opens Menu
            }
            else
            {
                CloseMenu(); //otherwise close the menu
            }
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnpauseGame();//resumes gameplay
        menuPanel.SetActive(false); //hide menu
        Cursor.visible = false; //hide cursor
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame(); //pauses gameplay
        menuPanel.SetActive(true); //show menu
        Cursor.visible = true; //show cursor
    }
}
