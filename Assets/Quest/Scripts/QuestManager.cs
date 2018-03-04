using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
    private Quest currentQuest = null;
    private Collider currentClient = null;

    private bool isOnMission = false;
    private bool isDone = false;
    private bool isSuccess = false;

    private float timer = 0.0f;

    public Collider CurrentClient
    {
        get { return currentClient; }
        set { currentClient = value; }
    }

    public bool IsOnMission
    {
        get
        {
            return isOnMission;
        }

        set
        {
            isOnMission = value;
        }
    }

    public bool IsDone
    {
        get
        {
            return isDone;
        }

        set
        {
            isDone = value;
        }
    }

    public bool IsSuccess
    {
        get
        {
            return isSuccess;
        }

        set
        {
            isSuccess = value;
        }
    }

    public void ActivateQuest(Quest quest, Collider client)
    {
        currentQuest = quest;
        currentQuest.Timer = 1200.0f;
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
