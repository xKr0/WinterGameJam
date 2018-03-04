using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHUDManager : MonoBehaviour {

    [SerializeField] private GameObject questHUD;
    [SerializeField] private Text text;
    [SerializeField] private Slider slider;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateHUD(Quest quest)
    {
        questHUD.SetActive(true);
        text.text = quest.Text;
        slider.maxValue = quest.Timer;
        slider.value = quest.Timer;
    }


}
