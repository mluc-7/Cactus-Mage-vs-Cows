using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    PauseManager pauseManager;

    [SerializeField] List<UpgradeButton> upgradeButtons;
    [SerializeField] GameObject player;
    void Awake()
    {
        if (pauseManager == null)
        {
            pauseManager = GetComponent<PauseManager>(); //can use GetComponent because pause manager is attached to the same component
        }
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        Cursor.visible = true; //make cursor visible
        pauseManager.PauseGame(); //pauses game
        upgradePanel.SetActive(true); //opens upgrade panel


        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true); //activates each upgrade button
            upgradeButtons[i].Set(upgradeDatas[i]); //set the corresponding upgrade data to each button    
        }
    }
    
    public void Clean() //remove icons after they have been taken out of the available pool and acquired
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        player.GetComponent<Level>().Upgrade(pressedButtonID); //registers which button was pressed
        ClosePanel();
    }

    public void ClosePanel()
    {
        HideButtons();
        Cursor.visible = false; //hides cursor
        pauseManager.UnpauseGame();//unpauses game
        upgradePanel.SetActive(false);//closes upgrade panel
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

}
