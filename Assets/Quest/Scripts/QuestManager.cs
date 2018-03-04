using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
    private Collider currentClient = null;

    private bool isOnMission = false;

    private float timer = 0.0f;

    public Collider CurrentClient
    {
        get { return currentClient; }
        set { currentClient = value; }
    }

    public bool IsOnMission
    {
        get { return isOnMission; }
        set { isOnMission = value; }
    }

    public void ActivateQuest(Collider client)
    {
        currentClient = client;
        currentClient.GetComponent<Detector>().OnDetect += TestColor;
        isOnMission = true;
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

        if (timer >= currentClient.GetComponent<FarmerQuest>().Quest.Timer)
        {
            FailQuest();
        }
    }

    void TestColor(ColorSheepEnum testColor)
    {
        // unregister event
        currentClient.GetComponent<Detector>().OnDetect -= TestColor;

        if (testColor == currentClient.GetComponent<FarmerQuest>().Quest.ColorGoal)
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
        Debug.Log("success");
        FarmerQuest clientQuest = currentClient.GetComponent<FarmerQuest>();
        clientQuest.Quest.IsDone = true;
        clientQuest.Quest.IsSuccess = true;
        ResetAll();
    }

    void FailQuest()
    {
        Debug.Log("fail");
        FarmerQuest clientQuest = currentClient.GetComponent<FarmerQuest>();
        clientQuest.Quest.IsDone = true;
        ResetAll();
    }

    void ResetAll()
    {
        isOnMission = false;
        currentClient = null;
        timer = 0.0f;
    }
}
