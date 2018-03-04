using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerQuest : MonoBehaviour {

    private Quest quest;
    [SerializeField] private GetDialog csvManager;
    List<string> colors = new List<string>();

    // Use this for initialization
    void Start ()
    {
        colors = csvManager.getColor();
        GenerateQuest();
        //Debug.Log(quest);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private string GetRandomColor()
    {
        string randomColor = colors[Random.Range(0, colors.Count)];
        return randomColor;
    }

    void GenerateQuest()
    {
        string color = GetRandomColor();
        quest = new Quest(color, csvManager.getTextQuete(color));
    }
}
