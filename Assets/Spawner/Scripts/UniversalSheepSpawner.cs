using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSheepSpawner : MonoBehaviour {

    // Use this for initialization
    [Tooltip("The sheep prefab to be spawned")]
    [SerializeField] private GameObject sheep;        // The red sheep prefab to be spawned.

    [Tooltip("Its Color")]
    [SerializeField] private ColorSheepEnum colorEnum;

    [Tooltip("Time between spawn")]
    [SerializeField] private float spawnTime = 1.5f;    
    // How long between each spawn.
    [Tooltip("Position where the sheep can spawn")]
    [SerializeField] private Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.

    [Tooltip("Price to spawn this kind of sheep")]
    [SerializeField] private int price = 5;

    [Tooltip("Sound to play when popping")]
    [SerializeField]  AudioSource source;

    LevelManager levelManager;

    [SerializeField]
    private float propulsion = 1000;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("SpawnAtStart", spawnTime, spawnTime);
    }

    void SpawnAtStart()
    {
        if (!LevelManager.ONCE_ALL_SPAWNED)
        {
            if (LevelManager.NB_SHEEPS >= levelManager.MAX_SHEEP)
            {
                LevelManager.ONCE_ALL_SPAWNED = true;
            }
            Spawn();
        }
    }

    public void Spawn(){

        LevelManager.NB_SHEEPS++;
        sheep.GetComponent<ColorModule>().MyColor = colorEnum;

        GameObject o = Instantiate(sheep, spawnPoint.position, spawnPoint.rotation);
                
        o.GetComponent<SheepAgent>().enabled = false;

        o.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * propulsion);

        o.GetComponent<ResetBehaviour>().enabled = true;

        source.Play();
    }

     void OnTriggerStay(Collider collider){
        if (PlayerSpec.pressSpawn && collider.gameObject.tag.Equals("Player"))
        {
            if (price <= levelManager.Money)
            {
                levelManager.RemoveMoney(price);
                Spawn();
            }
            else
            {
                //play error sound
            }
        }
    }
              
}
