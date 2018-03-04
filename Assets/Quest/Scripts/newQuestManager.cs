﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newQuestManager : MonoBehaviour 
{
    private Quest currentQuest = null;
    private Collider currentClient = null;
    private bool isOnMission = false;
    [SerializeField] private GameObject questHUD;
    [SerializeField] private Text text;

    private float timer = 0.0f;

    public Collider CurrentClient
    {
        get { return currentClient; }
        set { currentClient = value; }
    }

    public void ActivateQuest(Quest quest, Collider client)
    {
        currentQuest = quest;
        currentQuest.Timer = 1200.0f;
        currentClient = client;
        currentClient.GetComponent<Detector>().OnDetect += TestColor;
        isOnMission = true;
        questHUD.SetActive(true);
        text.text = quest.Text;
    }

    void Update()
    {
        if (isOnMission)
        {
            TickTock();
        }
    }

    void TickTock()
    {
        timer += Time.deltaTime;

        if (timer >= currentQuest.Timer)
        {
            FailQuest();
        }
    }

    void TestColor(ColorManager.ColorList testColor)
    {
        // unregister event
        currentClient.GetComponent<Detector>().OnDetect -= TestColor;

        if (testColor == ColorManager.ColorList.Red)
        {
            SucceedQuest();
        }
        else
        {
            FailQuest();
        }
    }

    void SucceedQuest()
    {
        Debug.Log("Success!");
        ResetAll();
    }

    void FailQuest()
    {
        Debug.Log("Fail");
        ResetAll();
    }

    void ResetAll()
    {
        isOnMission = false;
        currentQuest = null;
        currentClient = null;
        timer = 0.0f;
    }
}
