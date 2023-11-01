using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class TimeUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }

    }
    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f); //gives number of minutes
        int seconds = (int)(time % 60f); //modulus of whats left over from 60 seconds will give the remaining seconds

        text.text = minutes.ToString() + ":" + seconds.ToString("00");  //"00" in the ToString ensures that there will always be 2 digits for seconds
    }
    
}
