using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerQuest : MonoBehaviour {

    private Quest quest;
    private bool isInteracting = false;
    [SerializeField] private GetDialog csvManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private TextBoxManager textBoxManager;
    [SerializeField] private QuestHUDManager questHUD;

    List<string> colors = new List<string>();

    private FarmerStateMachine fsmFarmer;

    public bool IsInteracting
    {
        get { return isInteracting; }
        set { isInteracting = value; }
    }

    public Quest Quest
    {
        get { return quest; }
        set { quest = value; }
    }

    public QuestManager QuestManager
    {
        get { return questManager; }
        set { questManager = value; }
    }

    // Use this for initialization
    void Start ()
    {
        colors = csvManager.getColor();
        fsmFarmer = new FarmerStateMachine(this);
    }
	
	// Update is called once per frame
	void Update ()
    {      
        fsmFarmer.ProcessInput();    
	}

    public void ShowRandomText()
    {
        textBoxManager.Write(csvManager.getTextDialog("Random"));
    }

    public void ShowAcceptText()
    {
        textBoxManager.Write(csvManager.getTextDialog("Accept"));
    }

    private string GetRandomColor()
    {
        return colors[UnityEngine.Random.Range(0, colors.Count)];
    }

    public void PickRandomQuest()
    {
        string color = GetRandomColor();
        quest = new Quest(color, csvManager.getTextQuete(color));
    }

    public void ShowQuestText()
    {
        textBoxManager.Write(quest.Text);
    }

    public void ShowSuccessText()
    {
        textBoxManager.Write(csvManager.getTextDialog("Success"));
    }

    public void Success()
    {
        
        EndCurrentQuest();
    }
    public void Fail()
    {
        EndCurrentQuest();
    }

    public void EndCurrentQuest()
    {
        questHUD.DesactiveHUD();
        quest = null;
    }

    public void ShowHelloText()
    {
        textBoxManager.Write(csvManager.getTextDialog("Hello"));
    }

    public void ShowFailText()
    {
        textBoxManager.Write(csvManager.getTextDialog("Fail"));
    }

    public void AcceptQuest()
    {
        questManager.ActivateQuest(this.GetComponent<Collider>());
        questHUD.ActivateHUD(quest);
    }

    public void StopTalking()
    {
        textBoxManager.stopSpeaking();
    }

}
