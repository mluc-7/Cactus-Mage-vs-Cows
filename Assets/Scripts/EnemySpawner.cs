using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;

    private void Start()
    {
        if (enemyList.Count == 0) //show an error if the enemylist is empty
        {
            Debug.Log("Error: enemy list is empty.");
        }
    }

    public void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition(); //generates a random location to spawn the enemy

        position += player.transform.position; //the location wwill be centred around the player so that the enemy always spawns nearby the player
        GameObject enemy = enemyList[Random.Range(0, enemyList.Count)]; //generates a random value between 0 and the range of enemyList to randomly pick an enemy to spawn
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player); //set player as the target that the enemy will move towards
        newEnemy.transform.parent = transform; //spawns new enemies as children of the EnemiesContainer
    }

    //generate a random value to assign the spawn area of the enemy
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value;
        if (f > 0.5f)
        {
            f = -1f;
        }
        else
        {
            f = 1f;
        }
        if(UnityEngine.Random.value > 0.5f) //to determine the direction the spawn would be in
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x); //left or right
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y); //down or up
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
