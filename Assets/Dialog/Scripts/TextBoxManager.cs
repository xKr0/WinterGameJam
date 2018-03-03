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
	}

    void Update()
    {
        if (Input.GetButtonUp("B") )
        {
            NextLine();
        }
    }

    public void NextLine()
    {
        text.text = textLines[currentLine];
        if (textLines[currentLine].Contains(";"))
        {
            textBox.SetActive(false);
        } else
        {
            textBox.SetActive(true);
        }
        currentLine++;

    }

}
