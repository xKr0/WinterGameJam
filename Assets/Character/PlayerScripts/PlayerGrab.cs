using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    [SerializeField] float maxDetectDist;
    [SerializeField] float distFromPlayer;
    [SerializeField] float speedThrow;

    private Collider carriedSheep = null;
    private bool isHolding = false;
	
	void Update() 
    { 
        if (!isHolding)
        {
            if (PlayerSpec.pressGrab)
            {
                CheckTagInRange();
            }
        }
        else
        {
            if (carriedSheep != null)
            {
                carriedSheep.transform.position = transform.position + transform.forward * distFromPlayer;
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
	}

    void CheckTagInRange()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f))
        {
            if (hit.collider.tag == "Sheep")
            {
                carriedSheep = hit.collider;
                Grab();
            }
        }
    }
     
    void Grab()
    {
        isHolding = true;
        carriedSheep.GetComponent<Sheep>().IsGrabbed = true;
        carriedSheep.GetComponent<SheepAgent>().enabled = false;
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
        carriedSheep.attachedRigidbody.isKinematic = false;
        carriedSheep.attachedRigidbody.AddForce(transform.forward * speedThrow);
        carriedSheep.GetComponent<ResetBehaviour>().enabled = true;

        isHolding = false;
        carriedSheep = null;
    }
}
