using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    private Text text;
    //Detect if the current dialog is a mission
    private bool isMission = false;
    public bool acceptMission = false;


	// Use this for initialization
	void Start () {
        text = textBox.GetComponentInChildren<Text>();
        /*csvManager = csvManager.GetComponent<GetDialog>();
        textBox.SetActive(false);
        
        if (farmer.name == "Farmer1")
        {
            textColor = new Color(255, 255, 0);
        }
        else
        {
            textColor = new Color(0, 255, 255);
        }
        Debug.Log(csvManager.getColor());*/
	}

    void Update()
    {

    }


    public void WriteQuest(Quest quest)
    {
        text.text = quest.Text;
        textBox.SetActive(true);
    }

    public void stopSpeaking()
    {
        textBox.SetActive(false);
    }

    public void QuestAccept()
    {
        acceptMission = true;
        textBox.SetActive(false);
    }
}