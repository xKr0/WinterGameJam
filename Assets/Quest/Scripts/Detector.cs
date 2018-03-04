using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour 
{
    [SerializeField] string tagToDetect = "Sheep";

    event Action<Collider> _onDetect;
    public event Action<Collider> OnDetect
    {
        add { _onDetect += value; }
        remove { _onDetect -= value; }
    }       

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToDetect)
        {
            if (_onDetect != null)
            {               
                _onDetect(other);
            }
        }
    }
}
