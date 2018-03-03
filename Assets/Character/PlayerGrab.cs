using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    [SerializeField] float maxDetectDist;
    [SerializeField] float distFromPlayer;

    private Collider carriedSheep = null;

    private bool isHolding = false;
	
	void Update() 
    {
        float l = Input.GetAxis("LeftTrigger");
        float r = Input.GetAxis("RightTrigger");
        Debug.Log(l + " / " + r);

        if (!isHolding)
        {
            if (Input.GetButtonUp("X"))
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
            }

            if (Input.GetButtonUp("X"))
            {
                LetGo();
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
                Grab(hit.collider);
            }
        }
    }
     
    void Grab(Collider col)
    {
        isHolding = true;
        carriedSheep = col;

        col.GetComponent<SheepAgent>().enabled = false;
        col.GetComponent<Animator>().SetBool("Running", false);
        col.attachedRigidbody.isKinematic = true;
    }

    void LetGo()
    {
        carriedSheep.attachedRigidbody.isKinematic = false;
        carriedSheep.GetComponent<Animator>().SetBool("Running", true);
        carriedSheep.GetComponent<SheepAgent>().enabled = true;

        isHolding = false;
        carriedSheep = null;
    }
}
