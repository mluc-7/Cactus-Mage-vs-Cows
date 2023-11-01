using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int xp = 0;
    [SerializeField] int level = 1;
    [SerializeField] XpBar xpBar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;  //list of upgrades available to the player
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades; //list of upgrades applied to the player


    int xpThreshold
    {
        get
        {
            return level * 1000; //sets the xpThreshold to level * 1000
        }
    }

    private void Start()
    {
        xpBar.UpdateXpBar(xp, xpThreshold);
        xpBar.SetLevelText(level);
    }

    private void Update()
    {
        xpBar.UpdateXpBar(xp, xpThreshold);
        xpBar.SetLevelText(level);
    }

    //adds xp to the player, checks if it passes the threshold to level up and updates the xp bar
    public void AddXp(int xpAmount)
    {
        xp += xpAmount;
        CheckLevelUp();
        xpBar.UpdateXpBar(xp,xpThreshold);
    }



    //checks if the xp passes the threshold and if it does, call the LevelUp function
    public void CheckLevelUp()
    {
        if(xp >= xpThreshold)
        {
            LevelUp();
        }
    }
    //upon level up, opens an upgradePanel populated with random upgrades from the list of availableUpgrades
    private void LevelUp()
    {
        if (selectedUpgrades == null)
        {
            selectedUpgrades = new List<UpgradeData>(); //initialize list of upgrades
        }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4)); //get 4 upgrades and add it to the selectedUpgrades list


        upgradePanel.OpenPanel(selectedUpgrades); //allocate the selected upgrades to the upgrade panel
        xp = xp - xpThreshold; 
        level++; //increase the level
        xpBar.SetLevelText(level);
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        if (acquiredUpgrades == null)
        {
            acquiredUpgrades = new List<UpgradeData>();
        }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.Upgrade:
                break;
        }

        acquiredUpgrades.Add(upgradeData); //add the upgradeData to the acquiredUpgrades list
        upgrades.Remove(upgradeData); //removed the upgrade from the upgrade pool

    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();
        
        if (count > upgrades.Count) //limits number of requested upgrades to the maximum number of upgrades
        {
            count  = upgrades.Count;
        }
        
        for (int i = 0; i < count; i++)//gets number of upgrades equal to count
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]); //randomly gets one upgrade from the list of upgrades
        }
        return upgradeList;
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }
}
