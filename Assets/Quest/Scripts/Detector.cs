using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour 
{
    [SerializeField] string tagToDetect = "Sheep";

    event Action<ColorList> _onDetect;
    public event Action<ColorList> OnDetect
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
                _onDetect(other.GetComponent<ColorModule>().MyColor);
            }
        }
    }
	
}
