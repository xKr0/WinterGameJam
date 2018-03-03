using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerDialogManager : MonoBehaviour {

    private CapsuleCollider collider;
    public bool waitForDialog = false;
    public bool isOnMission = false;

    // Use this for initialization
    void Start () {
        collider = this.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginMission()
    {
        isOnMission = true;
    }

    // Lorsque le fermier reçoit un mouton, et qu'il est en mission, il gère la fin de la mission (succès ou échec)
    public void EndMission()
    {
        isOnMission = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            waitForDialog = true;
        } 
        if (other.gameObject.tag == "Sheep" && isOnMission)
        {
            EndMission();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            waitForDialog = false;
        }

    }
}
