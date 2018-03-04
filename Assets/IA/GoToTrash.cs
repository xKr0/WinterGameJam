using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTrash : MonoBehaviour {

    bool isEnable = false;

    public bool IsEnable
    {
        get { return isEnable; }
        set { isEnable = value; }
    }

    Transform destination;

    public Transform Destination
    {
        set { destination = value; }
    }

    float timeBeforeDestroy = 1.5f;

    float timer = 0f;

    private void FixedUpdate()
    {
        if (isEnable)
        {
            float deltaTime = Time.fixedDeltaTime;
            timer += deltaTime;

            if (timer >= timeBeforeDestroy)
            {
                Destroy(this.gameObject);
            }

            // calculate direction from target to me
            Vector3 forceDirection =  destination.position - transform.position;

            // apply force on target towards me
            this.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * 1000 * Time.fixedDeltaTime);
        }
    }
}
