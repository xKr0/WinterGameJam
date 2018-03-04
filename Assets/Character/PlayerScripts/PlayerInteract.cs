using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour 
{
    Collider pnjCollider = null;

    void Update ()
    {
        if (pnjCollider != null && PlayerSpec.pressSpawn) {
            PnjInteraction();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PNJ")
        {
            pnjCollider = other;
        }       
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "PNJ")
        {
            pnjCollider = null;
            other.gameObject.GetComponent<FarmerQuest>().IsInteracting = false;
        }
    }

    void PnjInteraction(){
		PlayerSpec.moveH = 0.0f;
		PlayerSpec.moveV = 0.0f;
        PlayerSpec.canMove = false;
        pnjCollider.GetComponent<FarmerQuest>().IsInteracting = true;
    }
}
