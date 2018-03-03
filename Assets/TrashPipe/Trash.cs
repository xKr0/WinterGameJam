using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

    [SerializeField]
    Transform trashPoint;

    [SerializeField]
    Transform trashEntry;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Sheep"))
        {
            if (other.GetComponent<Sheep>().IsGrabbed)
            {
                FindObjectOfType<PlayerGrab>().LetGo();
            }

            other.GetComponent<Animator>().SetBool("Running", false);
            other.GetComponent<SheepAgent>().enabled = false;
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            other.GetComponent<BoxCollider>().isTrigger = true;
            

            other.transform.SetPositionAndRotation(trashEntry.position, Quaternion.identity);

            GoToTrash goToTrash = other.GetComponent<GoToTrash>();
            goToTrash.Destination = trashPoint;
            goToTrash.IsEnable = true;
        }
    }
}
