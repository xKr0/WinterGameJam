using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    private string text;
    private ColorSheepEnum colorGoal;
    private int reward;
    private float timer;
    [SerializeField] private GetDialog csvManager;
    private List<string> colorList;

    private bool isDone = false;
    private bool isSuccess = false;

    public bool IsDone
    {
        get { return isDone; }
        set { isDone = value; }
    }

    public bool IsSuccess
    {
        get { return isSuccess; }
        set { isSuccess = value; }
    }

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

    public ColorSheepEnum ColorGoal
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
        colorGoal = ColorManager.GetEnumByName(color);
        Text = text;
        reward = 15;
        timer = 60.0f;
    }

    public override string ToString()
    {
        return colorGoal + " " + text + " " + reward + " " + timer;
    }
}
