using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour 
{
    [SerializeField] ParticleSystem pouffx;
    [SerializeField] GameObject model;

    public void TriggerFX()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pouffx.Play();
        model.SetActive(false);
    }

    bool isGrabbed = false;

    public bool IsGrabbed
    {
        get { return isGrabbed; }
        set { isGrabbed = value; }
    }
}
