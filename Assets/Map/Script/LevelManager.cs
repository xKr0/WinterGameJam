using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static int NB_SHEEPS = 0;

    public static int NB_COLOR_TO_WIN = 4;

    public static int NB_FAILS = 0;

    public static bool ONCE_ALL_SPAWNED = false;

	public static int MAX_HEALTH = 5;

    public int MAX_SHEEP = 25;
	// Use this for initialization

    [SerializeField] AudioSource source;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject rainbowPanel;
    [SerializeField] GameObject colorPrefab;

    private List<ColorSheepEnum> colorSuccess = new List<ColorSheepEnum>();

    int money = 30;
    public int Money{ get{return money;} set{money = value;}}

    public void AddMoney(int amount){
        //play gliggling sound
        source.Play();
        money += amount;
    }

    public void RemoveMoney(int amount){
        //play gliggling sound
        source.Play();
        money -= amount;
    }

    public void AddColor(ColorSheepEnum newColor)
    {
        if (!colorSuccess.Contains(newColor))
        {
            colorSuccess.Add(newColor);
        }
    }

    public void CheckWin()
    {
        if (colorSuccess.Count == NB_COLOR_TO_WIN)
        {
            Time.timeScale = 0.0f;
            winPanel.SetActive(true);

            AdaptWinPanel();
        }
    }

    public void AdaptWinPanel()
    {
        foreach (ColorSheepEnum color in colorSuccess)
        {
            GameObject colorCell = Instantiate(colorPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Color tmp = ColorManager.GetColorFromEnum(color);
            Color tmp2 = new Color((float)tmp.r/255f, (float)tmp.g/255f, (float)tmp.b/255f, 1f);
            colorCell.GetComponent<Image>().color = tmp2;
            colorCell.transform.SetParent(rainbowPanel.transform, false);
        }
    }
}
