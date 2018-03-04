using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    private string text;
    private string colorGoal;
    private int reward;
    private float timer;
    [SerializeField] private GetDialog csvManager;
    private List<string> colorList;

    public string Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }

    public string ColorGoal
    {
        get
        {
            return colorGoal;
        }

        set
        {
            colorGoal = value;
        }
    }

    public int Reward
    {
        get
        {
            return reward;
        }

        set
        {
            reward = value;
        }
    }

    public float Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }

    public Quest(string color, string text)
    {
        ColorGoal = color;
        Text = text;
        reward = 10;
        timer = 240.0f;
    }

    public override string ToString()
    {
        return colorGoal + " " + text + " " + reward + " " + timer;
    }
}
