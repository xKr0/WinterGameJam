using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static int NB_SHEEPS = 0;

    public static bool ONCE_ALL_SPAWNED = false;

    public static int MAX_SHEEP = 15;
	// Use this for initialization

    int money;
    public int Money{ get{return money;} set{money = value;}}



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddMoney(int amount){
        money += amount;
    }

    public void RemoveMoney(int amount){
        money -= amount;
    }
}
