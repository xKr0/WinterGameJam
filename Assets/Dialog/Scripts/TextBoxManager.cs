using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    private Text text;

    //Detect if the current dialog is a mission
    public bool acceptMission = false;


	// Use this for initialization
	void Start () {
        text = textBox.GetComponentInChildren<Text>();
	}

    public void Write(string texte)
    {
        textBox.SetActive(true);
        text.text = texte;
    }

    public void stopSpeaking()
    {
        textBox.SetActive(false);
    }

    public void QuestAccept()
    {
        acceptMission = true;
        textBox.SetActive(false);
    }
}