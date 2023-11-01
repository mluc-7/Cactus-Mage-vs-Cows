using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] GameObject levelCompletePanel;
    private void Awake()
    {
        if (stageTime== null)
        {
            stageTime = GetComponent<StageTime>();
        }
        pauseManager = FindObjectOfType<PauseManager>();
    }

    public void Update()
    {
        if(stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelCompletePanel.SetActive(true);
        }
    }
}
