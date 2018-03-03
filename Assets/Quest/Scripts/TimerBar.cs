using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour {

    [SerializeField] private Slider slider;
    private float initialValue;
    [SerializeField] private Image fill;
    [SerializeField] private GameObject quest;
    // Use this for initialization
    void Start()
    {
        slider = slider.GetComponent<Slider>();
        initialValue = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = slider.value - (0.035f * Time.deltaTime);
        //fill.color = Color.red;
        if (slider.value <= initialValue/10)
        {
            fill.color = Color.red;
        }

        else if (slider.value <= initialValue/2 && slider.value >= initialValue/10)
        {
            fill.color = Color.yellow;
        }
    }

    public void AcceptQuest()
    {
        Instantiate(quest);
        quest.SetActive(true);
        Debug.Log("OK");
    }
}