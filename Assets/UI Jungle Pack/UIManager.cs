using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;

    public Transform pauseMenu;
    public Transform HUD;
    public Transform gameOverMenu;
    public Transform controls;

    [SerializeField] GameObject reprendre;
    [SerializeField] GameObject controles;
    [SerializeField] GameObject quitter;
    [SerializeField] GameObject back;


    // Pause Menu
    public static bool isPaused = false;
    private bool showControls = false;

    private bool isGameOver;

    void Awake()
    {
        pauseMenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(reprendre);
        //HUD.gameObject.SetActive(true);
        //gameOverMenu.gameObject.SetActive(false);
    }


    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;
        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;
        pauseMenu.gameObject.SetActive(true);
        // Select the button
        reprendre.GetComponent<Button>().Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
        // Highlight the button
        reprendre.GetComponent<Button>().OnSelect(null); // Or myButton.OnSelect(new BaseEventData(EventSystem.current))

        isPaused = true;
    }
    private void MenuOff ()
    {
        isPaused = false;
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        pauseMenu.gameObject.SetActive(false);
    }

    // Sera appelée en appuyant sur start
    public void PauseMenuStatusChange ()
    {
        if (!isPaused)
        {
            MenuOn();
        }
        else if (isPaused)
        {
            MenuOff();
        }
    }

    private void UploadPauseMenu()
    {
        /*for (int i = 0; i < 3; i++) 
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
        */
    }

    public void ShowControls()
    {
        controls.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        showControls = true;
        // Select the button
        back.GetComponent<Button>().Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
        // Highlight the button
        back.GetComponent<Button>().OnSelect(null); // Or myButton.OnSelect(new BaseEventData(EventSystem.current))
    }
    public void HideControls()
    {
        controls.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        showControls = false;
        EventSystem.current.SetSelectedGameObject(reprendre);
        // Select the button
        reprendre.GetComponent<Button>().Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
        // Highlight the button
        reprendre.GetComponent<Button>().OnSelect(null); // Or myButton.OnSelect(new BaseEventData(EventSystem.current))
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
	{
	    if (Input.GetButtonUp("Start"))
        { 
            PauseMenuStatusChange();
        }
	}

}
