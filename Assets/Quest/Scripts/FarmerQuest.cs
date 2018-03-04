using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerQuest : MonoBehaviour {

    private Quest quest;
    private bool isInteracting = false;
    [SerializeField] private GetDialog csvManager;
    [SerializeField] private newQuestManager questManager;
    [SerializeField] private TextBoxManager textBoxManager;
    List<string> colors = new List<string>();

    public bool IsInteracting
    {
        get
        {
            return isInteracting;
        }

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
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(isInteracting && questManager.CurrentClient == null)
        {
            textBoxManager.WriteQuest(quest);
            //Apres avoir accepter la quete
            PlayerSpec.canMove = false;
            if (PlayerSpec.pressSubmit)
            {
                Debug.Log("Quete accepte");
                questManager.ActivateQuest(quest, this.GetComponent<Collider>());
                PlayerSpec.canMove = true;
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
}
