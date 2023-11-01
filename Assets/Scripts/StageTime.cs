using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimeUI timeUI;

    private void Awake()
    {
        timeUI = FindObjectOfType<TimeUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;// cumulative elapsed time
        timeUI.UpdateTime(time); //Updates time 
    }
}
