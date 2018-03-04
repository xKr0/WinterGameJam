using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
    private Collider currentClient = null;

    private PlayerGrab playerGrab;

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

    void Start() 
    {
        playerGrab = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrab>();
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

    void TestColor(Collider other)
    {
        if (currentClient != null)
        {
            // unregister event
            currentClient.GetComponent<Detector>().OnDetect -= TestColor;

            ColorSheepEnum color = other.GetComponent<ColorModule>().MyColor;

            other.transform.GetComponent<SheepAgent>().enabled = false;

            if (color == currentClient.GetComponent<FarmerQuest>().Quest.ColorGoal)
            {
                SucceedQuest();
            }
            else
            {
                FailQuest();
            }

            DespawnSheep(other);
        }
    }

    void DespawnSheep(Collider col)
    {
        if (playerGrab.CarriedSheep == col)
        {
            playerGrab.LetGo();
            col.transform.GetComponent<SheepAgent>().enabled = false;
        }

        col.GetComponent<Sheep>().TriggerFX();
        Destroy(col.gameObject, 2.0f);
    }


    void SucceedQuest()
    {
        Debug.Log("success");
        FarmerQuest clientQuest = currentClient.GetComponent<FarmerQuest>();
        clientQuest.TurnOnQuestReward();
        clientQuest.Quest.IsDone = true;
        clientQuest.Quest.IsSuccess = true;        
        ResetAll();
    }

    void FailQuest()
    {
        currentClient.GetComponent<FarmerQuest>().TurnOnQuestReward();
        Debug.Log("fail");
        FarmerQuest clientQuest = currentClient.GetComponent<FarmerQuest>();
        clientQuest.TurnOnQuestReward();
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
