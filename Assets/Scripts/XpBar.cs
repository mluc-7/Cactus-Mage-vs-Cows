using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpBar : MonoBehaviour
{
    [SerializeField] Transform xpBar;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    //changes the xpBar by changing the x-scale
    public void UpdateXpBar (int currentXp, int xpThreshold)
    {
        float xpPercent = ((float)currentXp) / xpThreshold;
        if (xpPercent < 0)
        {
            xpPercent = 0f; //if xp drops below 0, set to zero
        }
        xpBar.transform.localScale = new Vector3(xpPercent, 1f, 1f);
    }

    public void SetLevelText(int level)
    {
        levelText.text = "Lvl: " + level.ToString(); //updates the levelText
    }
}
