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

	// Use this for initialization
	void Start () {

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
        // Si le joueur clique sur B à côté du farmer ou qu'il avait déjà engagé le dialogue
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
        text.text = textLines[currentLine];
        text.color = textColor;
        if (textLines[currentLine].Contains(";"))
        {
            farmer.GetComponent<FarmerDialogManager>().BeginMission();
            textBox.SetActive(false);
        } else
        {
            textBox.SetActive(true);
        }
        currentLine++;

    }

}
