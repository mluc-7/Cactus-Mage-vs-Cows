using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemySpawner enemySpawner;

    StageTime stageTime;
    int eventIndexer;

    private void Awake()
    {
        if (stageTime == null)
        {
            stageTime = GetComponent<StageTime>();
        }
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) 
        {
            return; //does not proceed if the indexer goes out of bounds
        }
        if(stageTime.time > stageData.stageEvents[eventIndexer].time) //checks for when the elapsed stage time passes the allocated time for when the stageEvent occurs
        {
            Debug.Log(stageData.stageEvents[eventIndexer].message);

            for (int i = 0; i < stageData.stageEvents[eventIndexer].enemyCount; i++) 
            {
                enemySpawner.SpawnEnemy(); //spawn enemies using enemySpawner script for the number of times in enemyCount
            }

            eventIndexer ++; //increment eventIndexer by 1
        }
    }

}
