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

    public bool IsInteracting
    {
        get { return isInteracting; }

        set
        {
            isInteracting = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        colors = csvManager.getColor();
        GenerateQuest();
        //Debug.Log(quest);
        hello = csvManager.getTextDialog("hello");
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
         if (neverSeen && isInteracting)
         {
            PlayerSpec.canMove = false;
            //Debug.Log("Dialogue");
            textBoxManager.WriteDialog(hello);
            if (PlayerSpec.pressSubmit)
            {
                neverSeen = false;
            }
         }

        else if (isInteracting && questManager.CurrentClient == null)
        {
            textBoxManager.WriteQuest(quest);
            //Apres avoir accepter la quete
            PlayerSpec.canMove = false;
            if (PlayerSpec.pressSubmit)
            {
                AcceptQuest();
            }
            else if (PlayerSpec.pressCancel)
            {
                Debug.Log("Quete refuse");
                PlayerSpec.canMove = true;
                isInteracting = false;
            }
        }
        else
        {
            //Apres avoir accepter ou refuse
            textBoxManager.stopSpeaking();
        }               
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

    private void AcceptQuest()
    {
        Debug.Log("Quete accepte");
        questManager.ActivateQuest(quest, this.GetComponent<Collider>());
        questHUD.ActivateHUD(quest);
        PlayerSpec.canMove = true;
    }
}
