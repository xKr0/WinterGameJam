using UnityEngine;
using System.Collections.Generic;

public class SheepAgent : Agent
{
    [Header("Steering Behaviours")]
    [SerializeField] WanderBehaviour wander;
    //[SerializeField] Sensor preyInSight;


    
    void Start()
    {
        InitializePrioritizedBehaviours(new List<SteeringBehaviour>(3)
            {
                wander,
            });

    }

    void Update()
    {
       
    }

   
    void OnCollisionEnter(Collision col)
    {
       
    }


}
