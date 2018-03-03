using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour 
{
    bool isPnjInteraction = false;

    void FixedUpdate ()
    {
        if (isPnjInteraction && PlayerSpec.pressTalk) {
            PnjInteraction ();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PNJ") isPnjInteraction = true;
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "PNJ") isPnjInteraction = false;
    }

    void PnjInteraction(){
        Debug.Log ("Interaction PNJ");
    }
}
