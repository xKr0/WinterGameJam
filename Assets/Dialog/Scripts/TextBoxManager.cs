using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text text;
    public GameObject farmer;
    public Color textColor ;
    //Detect if the current dialog is a mission
    private bool isMission = false;
    public bool acceptMission = false;
    [SerializeField] private GetDialog csvManager;

    private string currentQuest;
    private List<string> Color;

	// Use this for initialization
	void Start () {

        csvManager = csvManager.GetComponent<GetDialog>();
        textBox.SetActive(false);
        
        if (farmer.name == "Farmer1")
        {
            textColor = new Color(255, 255, 0);
        }
        else
        {
            textColor = new Color(0, 255, 255);
        }
        Debug.Log(csvManager.getColor());
	}

    void Update()
    {
        if(Input.GetButtonUp("A") && isMission)
        {
            Debug.Log("ok"); 
            QuestAccept();
        }
        /*if (Input.GetButtonUp("B") && textBox.active)
        {
            textBox.SetActive(false);
        }*/
        if (Input.GetButtonUp("B") && (farmer.GetComponent<FarmerDialogManager>().waitForDialog))
        {
            NextLine();
        }

    }


    public void NextLine()
    {
        //text.text = GetCurrentQuest();
        text.color = textColor;
        isMission = true;
        textBox.SetActive(true);
    }

    public void QuestAccept()
    {
        acceptMission = true;
        textBox.SetActive(false);
    }

  



}
