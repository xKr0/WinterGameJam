using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour 
{
    [SerializeField] string tagToDetect = "Sheep";

    private PlayerGrab playerGrab;

    event Action<ColorSheepEnum> _onDetect;
    public event Action<ColorSheepEnum> OnDetect
    {
        add { _onDetect += value; }
        remove { _onDetect -= value; }
    }

    void Start()
    {
        playerGrab = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrab>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToDetect)
        {
            if (_onDetect != null)
            {
                ColorSheepEnum color = other.GetComponent<ColorModule>().MyColor;
                _onDetect(color);

                DespawnSheep(other);
            }
        }
    }

    void DespawnSheep(Collider col)
    {
        if (playerGrab.CarriedSheep == col)
        {
            playerGrab.LetGo();
        }

        Destroy(col.gameObject, 0.0f);
    }
	
}
