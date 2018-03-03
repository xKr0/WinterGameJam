using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

    // Use this for initialization
    [Tooltip("The red sheep prefab to be spawned")]
    [SerializeField] private GameObject Redsheep;        // The red sheep prefab to be spawned.
    [Tooltip("The blue sheep prefab to be spawned")]
    [SerializeField] private GameObject Greensheep;        // The blue sheep prefab to be spawned.
    [Tooltip("The green sheep prefab to be spawned")]
    [SerializeField] private GameObject Bluesheep;        // The green sheep prefab to be spawned.
    [Tooltip("Time between spawn")]
    [SerializeField] private float spawnTime = 3f;            // How long between each spawn.
    [Tooltip("Position where the sheep can spawn")]
    [SerializeField] public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private int sheepSpawnAmount =0;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the sheep prefab at the randomly selected spawn point's position and rotation.
        if (spawnPointIndex == 0)
        {
            Instantiate(Redsheep, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        else if (spawnPointIndex == 1)
        {
            Instantiate(Greensheep, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        else if (spawnPointIndex == 2)
        {
            Instantiate(Bluesheep, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        sheepSpawnAmount++;
        //Debug.Log(sheepSpawnAmount);
    }

    // Get the number of sheeps spawned
    int GetSheepNumber()
    {
        return sheepSpawnAmount;
    }
}
