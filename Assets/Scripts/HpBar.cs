using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] Transform hpBar;

    //changes hp bar by changing the x-scale
    public void ChangeHpBar(int currentHp, int maxHp)
    {
        float hpPercent = ((float) currentHp)/ maxHp;
        if(hpPercent <0 ) //if ho falls below 0, set hp to 0
        {
            hpPercent = 0f;
        }
        hpBar.transform.localScale = new Vector3(hpPercent, 1f, 1f);
    }
}
