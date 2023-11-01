using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab  ;
    [SerializeField] [Range(0,1f)] float dropChance = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void Start()
    {
        if (dropItemPrefab.Count == 0) //show an error if the item drop list is empty
        {
            Debug.Log("Error: item drop list is empty.");
        }
    }
    public void CheckDrop()
    {
        if(isQuitting)
        {
            return;
        }

        //generates a random value to check if a item will be dropped
        if (Random.value < dropChance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)]; //randomly selects a random item prefab to drop from the item drop list
            Transform t = Instantiate(toDrop).transform; //instantiate the item
            t.position = transform.position; //drops the item at the location where this script is attached to (an enemy)
        }
        
    }
}
