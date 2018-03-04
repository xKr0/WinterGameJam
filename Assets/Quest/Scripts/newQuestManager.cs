using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newQuestManager : MonoBehaviour 
{
    private Quest currentQuest = null;
    private Collider currentClient = null;
    private bool isOnMission = false;

    private float timer = 0.0f;

    public void ActivateQuest(Quest quest, Collider client)
    {
        currentQuest = quest;
        currentClient = client;
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

    void RegisterClientEvent()
    {
        
    }

    void SucceedQuest()
    {
        Debug.Log("Time.out");
        ResetAll();
    }

    void FailQuest()
    {
        Debug.Log("Time.out");
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
