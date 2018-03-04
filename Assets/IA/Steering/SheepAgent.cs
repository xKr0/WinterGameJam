using UnityEngine;
using System.Collections.Generic;

public class SheepAgent : Agent
{
    [Header("Steering Behaviours")]
    [SerializeField] WanderBehaviour wander;
    //[SerializeField] Sensor preyInSight;

    [SerializeField] AudioSource source;


    
    void Start()
    {
        InitializePrioritizedBehaviours(new List<SteeringBehaviour>(3)
            {
                wander,
            });
        GetComponent<Animator>().SetBool("Running", true);
    }

    void Update()
    {
       
    }

   
    void OnCollisionEnter(Collision col)
    {
       
    }

    public void PlaySound(){
        source.Play();
    }

}
