using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;

    public Transform pauseMenu;
    public Transform HUD;
    public Transform gameOverMenu;
    public Transform controls;

    // Pause Menu
    public Sprite currentItemBG, otherItemsBG;
    public static bool isPaused = false;
    private bool showControls = false;
    private Transform[] choices = new Transform[3];
    private int currentChoice = 0;

    private bool isGameOver;

    public bool isStartPressed = false,
                isAPressed = false,
                isBPressed = false,
                isUpPressed = false,
                isDownPressed = false;


    void Awake()
    {
        Transform choix = pauseMenu.GetChild(0).GetChild(0).Find("Choix");
        choices[0] = choix.Find("Reprendre");
        choices[1] = choix.Find("Regles");
        choices[2] = choix.Find("Quitter");
        pauseMenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
        gameOverMenu.gameObject.SetActive(false);
    }


    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;
        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;
        pauseMenu.gameObject.SetActive(true);
        isPaused = true;
    }
    private void MenuOff ()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        pauseMenu.gameObject.SetActive(false);
        isPaused = false;
    }

    // Sera appelée en appuyant sur start
    private void PauseMenuStatusChange ()
    {
        Cursor.visible = isPaused; //force the cursor visible if anything had hidden it
        if (!isPaused)
        {
            MenuOn();
        }
        else if (isPaused)
        {
            MenuOff();
        }
    }

    // Sera appelée en appuyant sur haut/bas quand le menu est en pause
    private void NextChoice()
    {
        currentChoice++;
        if (currentChoice >= 3) currentChoice = 0;
        UploadPauseMenu();
    }
    public void PreviousChoice()
    {
        currentChoice--;
        if (currentChoice <= -1) currentChoice = 2;
        UploadPauseMenu();
    }

    // Sera appelé pour valider le choix sélectionné avec A
    private void PauseMenuValidate()
    {
        switch (currentChoice)
        {
            case 1:
                PauseMenuStatusChange();
                break;
            case 2:
                ShowControls();
                break;
            default:
                // AJOUTER ACTION DE FIN
                break;
        }
    }


    private void UploadPauseMenu()
    {
        for (int i = 0; i < 3; i++) 
        {
            if (i == currentChoice)
            {
                Debug.Log(choices[i].name);
                choices[i].GetComponent<Image>().sprite = currentItemBG;
            } else
            {
                choices[i].GetComponent<Image>().sprite = otherItemsBG;
            }
        }
    }

    private void ShowControls()
    {
        controls.gameObject.SetActive(true);
        showControls = true;
    }
    private void HideControls()
    {
        controls.gameObject.SetActive(false);
        showControls = false;
    }

#if !MOBILE_INPUT
    void Update()
	{
        if (isStartPressed)
        {
            PauseMenuStatusChange();
        }

        if (isPaused)
        {
            if (isUpPressed && !showControls)
            {
                PreviousChoice();
            }
            if (isDownPressed && !showControls)
            {
                NextChoice();
            }
            if (isBPressed)
            {
                if (showControls)
                {
                    HideControls();
                } else
                {
                    PauseMenuStatusChange();
                }
            }
            if (isAPressed)
            {
                if (showControls)
                {
                    HideControls();
                }
                else
                {
                    PauseMenuValidate();
                }
            }
        }
		
	}
#endif

}
