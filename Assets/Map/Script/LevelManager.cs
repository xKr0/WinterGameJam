using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static int NB_SHEEPS = 0;

    public static int NB_FAILS = 0;

    public static bool ONCE_ALL_SPAWNED = false;

	public static int MAX_HEALTH = 5;

    public int MAX_SHEEP = 25;
	// Use this for initialization

    [SerializeField] AudioSource source;

    int money = 30;
    public int Money{ get{return money;} set{money = value;}}

    public void AddMoney(int amount){
        //play gliggling sound
        source.Play();
        money += amount;
    }

    public void RemoveMoney(int amount){
        //play gliggling sound
        source.Play();
        money -= amount;
    }
}
