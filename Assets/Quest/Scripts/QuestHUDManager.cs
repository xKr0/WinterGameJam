﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHUDManager : MonoBehaviour
{

    [SerializeField] private GameObject questHUD;
    [SerializeField] private Text text;
    [SerializeField] private Slider slider;
	[SerializeField] private Image fill;

    public void ActivateHUD(Quest quest)
    {
        questHUD.SetActive(true);
        text.text = quest.Text;
        slider.maxValue = quest.Timer;
        slider.value = quest.Timer;
		fill.color = Color.green;
    }

    public void DesactiveHUD()
    {
        questHUD.SetActive(false);
    }
}
