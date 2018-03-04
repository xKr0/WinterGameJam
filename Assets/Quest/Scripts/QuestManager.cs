using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    private Quest currentQuest = null;
    private GameObject currentClient = null;

    /*[SerializeField] private Text questText;
    public TextBoxManager textBoxManagerFarmer1;
    public TextBoxManager textBoxManagerFarmer2;
    [SerializeField] private GameObject questHUD;
    [SerializeField] private Slider slider;
    private bool isOnQuest = false;
    private bool failQuest = false;*/

    public Quest CurrentQuest
    {
        get
        {
            return currentQuest;
        }

        set
        {
            currentQuest = value;
        }
    }

    public GameObject CurrentClient
    {
        get
        {
            return currentClient;
        }

        set
        {
            currentClient = value;
        }
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        //If a quest is accepted, display in HUD
       /* if (textBoxManagerFarmer1.acceptMission && isOnQuest == false)
        {
            Debug.Log("Test 1");
            questHUD.SetActive(true);
            ChangeText(textBoxManagerFarmer1);
            isOnQuest = true;
            slider.value = slider.maxValue;
        }
        if (textBoxManagerFarmer2.acceptMission && isOnQuest == false)
        {
            Debug.Log("Test 2");
            questHUD.SetActive(true);
            ChangeText(textBoxManagerFarmer2);
            isOnQuest = true;
            slider.value = slider.maxValue;
        }
        QuestFail();*/
    }

    // Change the text of the quest
    void ChangeText(TextBoxManager textBox)
    {
        //questText.text = /*textBox.GetCurrentQuest();*/ textBox.text.text;
    }

    void QuestFail()
    {
        /*if (slider.value == 0)
        {
            Debug.Log("Fail");
            questText.text = "Quete rate !";
        }*/
    }

    public override string ToString()
    {
        return currentClient + " " + currentQuest;
    }
}
