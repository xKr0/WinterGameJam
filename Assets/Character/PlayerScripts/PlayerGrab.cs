﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    [SerializeField] float maxDetectDist;
    [SerializeField] float distFromPlayer;
    [SerializeField] float speedThrow;
    [SerializeField] TriggerDetector triggerDetector;

    private Collider carriedSheep = null;

    public Collider CarriedSheep
    {
        get { return carriedSheep; }
    }

    private bool isHolding = false;

    private void Start()
    {
        triggerDetector.OnEnter += SetSheep;
    }

    void Update() 
    {
        if (!isHolding && PlayerSpec.pressGrab && carriedSheep != null)
        {
            Grab();
        }
        else if(isHolding)
        {
            carriedSheep.transform.position = transform.position + transform.forward * distFromPlayer + new Vector3(0f, 0.6f, 0f);
            carriedSheep.transform.rotation = Quaternion.LookRotation(transform.forward);

            if (PlayerSpec.pressGrab)
            {
                LetGo();
            }
            else
            {
                if (PlayerSpec.leftTrigger > 0.0f)
                {
                    Throw();
                }
                else if (PlayerSpec.rightTrigger > 0.0f)
                {
                    Throw();
                }

            }
        }
	}

    void SetSheep(Collider other)
    {
        if (!isHolding && other.tag == "Sheep")
        {
            carriedSheep = other;            
        }        
    }
     
    void Grab()
    {
        isHolding = true;
        carriedSheep.GetComponent<Sheep>().IsGrabbed = true;
        carriedSheep.GetComponent<SheepAgent>().enabled = false;
        carriedSheep.GetComponent<SheepAgent>().PlaySound();
        carriedSheep.GetComponent<Animator>().SetBool("Running", false);
        carriedSheep.attachedRigidbody.isKinematic = true;
    }

    public void LetGo()
    {
        carriedSheep.GetComponent<Sheep>().IsGrabbed = false;
        carriedSheep.attachedRigidbody.isKinematic = false;
        carriedSheep.GetComponent<Animator>().SetBool("Running", true);
        carriedSheep.GetComponent<SheepAgent>().enabled = true;

        isHolding = false;
        carriedSheep = null;
    }

    void Throw()
    {
        carriedSheep.GetComponent<Sheep>().IsGrabbed = false;
        carriedSheep.attachedRigidbody.isKinematic = false;
        carriedSheep.attachedRigidbody.AddForce(transform.forward * speedThrow);
        carriedSheep.GetComponent<ResetBehaviour>().enabled = true;
        carriedSheep.GetComponent<SheepAgent>().PlaySound();
        isHolding = false;
        carriedSheep = null;
    }
}
