﻿using System;
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
    private bool neverSeen = true;
    private string hello;
    private FarmerStateMachine fsmFarmer;

    public bool IsInteracting
    {
        get { return isInteracting; }

        set
        {
            isInteracting = value;
        }
    }

    public Quest Quest
    {
        get
        {
            return quest;
        }

        set
        {
            quest = value;
        }
    }

    public QuestManager QuestManager
    {
        get
        {
            return questManager;
        }

        set
        {
            questManager = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        colors = csvManager.getColor();
        fsmFarmer = new FarmerStateMachine(this);
        //Debug.Log(quest);
        hello = csvManager.getTextDialog("hello");
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (IsInteracting)
        {
            fsmFarmer.ProcessInput();
        }       
	}

    public void ShowRandomText()
    {
        throw new NotImplementedException();
    }

    public void ShowAcceptText()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Success()
    {
        throw new NotImplementedException();
    }
    public void Fail()
    {
        throw new NotImplementedException();
    }

    public void ShowHelloText()
    {
        textBoxManager.Write(hello);
    }

    public void ShowFailText()
    {
        throw new NotImplementedException();
    }

    public void AcceptQuest()
    {
        questManager.ActivateQuest(quest, this.GetComponent<Collider>());
        questHUD.ActivateHUD(quest);
    }

    public void StopTalking()
    {
        textBoxManager.stopSpeaking();
    }

}
