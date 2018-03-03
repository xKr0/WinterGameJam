using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text text;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine = 0;
    public int endAtLine = 0;

    public GameObject farmer;
    public Color textColor ;

    //Detect if the current dialog is a mission
    private bool isMission = false;

    public bool acceptMission = false;

    public GameObject AcceptQuest;

    [SerializeField] private GetDialog csvManager;

    public string currentQuest;

	// Use this for initialization
	void Start () {

        csvManager = csvManager.GetComponent<GetDialog>();
        textBox.SetActive(false);
        
		if (textFile != null)
        {            
            textLines = (textFile.text.Split('\n'));
            Debug.Log(textFile.text);
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length;
        }

        if (farmer.name == "Farmer1")
        {
            textColor = new Color(255, 255, 0);
        } else
        {
            textColor = new Color(0, 255, 255);
        }
	}

    void Update()
    {
        //Debug.Log(isMission);
        // Si le joueur clique sur B à côté du farmer ou qu'il avait déjà engagé le dialogue
        if(Input.GetButtonUp("A") && isMission)
        {
            Debug.Log("ok"); 
            QuestAccept();
        }
        if (Input.GetButtonUp("B") && (farmer.GetComponent<FarmerDialogManager>().waitForDialog || textBox.active))
        {
            // Si le joueur ne discutait pas déjà avec l'autre farmer
            if (textBox.active && (currentLine == 0 || textLines[currentLine - 1].Contains(";")))
                return;

            // Si le joueur à déjà une mission en cours
            if (farmer.GetComponent<FarmerDialogManager>().isOnMission)
            {
                AskForSheep();
            }
            NextLine();
        }
    }

    // Si il est en mission et que le joeur reparle au fermier, il répète sa dernière phrase
    public void AskForSheep()
    {
        currentLine--;
        text.text = textLines[currentLine];
        text.color = textColor;
        if (textLines[currentLine].Contains(";"))
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
            
        }
        currentLine++;
    }

    public void NextLine()
    {
        //text.text = textLines[currentLine];
        //text.text = csvManager.getTextQuete("Rouge");
        text.text = GetCurrentQuest();
        text.color = textColor;
        isMission = true;
        textBox.SetActive(true);
        /*if (textLines[currentLine].Contains(";"))
        {
            farmer.GetComponent<FarmerDialogManager>().BeginMission();
            isMission = false;
            acceptMission = false;
            textBox.SetActive(false);
        } else
        {
            isMission = true;
            textBox.SetActive(true);
        }*/
        //currentLine++;

    }

    public void QuestAccept()
    {
        acceptMission = true;
        textBox.SetActive(false);
    }

    public string GetCurrentQuest()
    {
        currentQuest = csvManager.getTextQuete("Rouge");
        return currentQuest;
    }

}
