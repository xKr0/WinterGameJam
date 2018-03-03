using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSheepSpawner : MonoBehaviour {

    // Use this for initialization
    [Tooltip("The sheep prefab to be spawned")]
    [SerializeField] private GameObject sheep;        // The red sheep prefab to be spawned.

    [Tooltip("Its Color")]
    [SerializeField] private ColorManager.ColorList colorEnum;

    [Tooltip("Time between spawn")]
    [SerializeField] private float spawnTime = 3f;    
    // How long between each spawn.
    [Tooltip("Position where the sheep can spawn")]
    [SerializeField] public Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.



    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("SpawnAtStart", spawnTime, spawnTime);
    }


    void SpawnAtStart()
    {
        if (!LevelManager.ONCE_ALL_SPAWNED)
        {
            LevelManager.NB_SHEEPS++;
            if (LevelManager.NB_SHEEPS >= LevelManager.MAX_SHEEP)
            {
                LevelManager.ONCE_ALL_SPAWNED = true;
            }
            Spawn();
        }
    }

    public void Spawn(){
        sheep.GetComponent<ColorModule>().MyColor = colorEnum;
        Debug.Log(sheep.GetComponent<ColorModule>().MyColor);
        GameObject o = Instantiate(sheep, spawnPoint.position, spawnPoint.rotation);


    }
        
}
