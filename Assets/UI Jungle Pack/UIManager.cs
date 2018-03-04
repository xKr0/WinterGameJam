using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;

    [SerializeField] Transform gameManager;

    [SerializeField] Sprite buttonSelected;
    [SerializeField] Sprite buttonNotSelected;
    [SerializeField] AudioClip changeSound;
    [SerializeField] AudioClip selectSound;

    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform HUD;
    [SerializeField] Transform gameOverMenu;
    [SerializeField] Transform controls;

    [SerializeField] Transform reprendre;
    [SerializeField] Transform controles;
    [SerializeField] Transform quitter;
    [SerializeField] Transform back;

    private AudioSource source;

    // Pause Menu
    public static bool isPaused = false;
    private bool showControls = false;
    public static bool pressStart = false;

    // HUD
    private Transform HUDText;

    private bool isGameOver;

    void Awake()
    {

        pauseMenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
        gameOverMenu.gameObject.SetActive(false);

        pauseMenu.gameObject.AddComponent<AudioSource>();
        source = this.GetComponent<AudioSource>();
        //Debug.Log(source != null);
        //source.playOnAwake = false;

        HUDText = HUD.GetChild(0).Find("Gold").Find("GoldLevel");
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

        isPaused = true;
    }
    private void MenuOff ()
    {
        isPaused = false;
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        pauseMenu.gameObject.SetActive(false);
    }

    // Sera appel�e en appuyant sur start
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

    public void ShowControls()
    {
        controls.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        showControls = true;
        // Select the button
        back.GetComponent<Button>().Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
        UnselectItem(controles);
    }
    public void HideControls()
    {
        controls.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        showControls = false;
        // Select the button
        reprendre.GetComponent<Button>().Select();
        UnselectItem(back);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SelectItem(Transform button)
    {
        button.GetComponent<Image>().sprite = buttonSelected;
        source.clip = changeSound;
        Debug.Log("ici" + source.clip != null);
        source.PlayOneShot(changeSound, 1.0f);

    }
    public void UnselectItem(Transform button)
    {
        button.GetComponent<Image>().sprite = buttonNotSelected;
    }

    void Update()
	{
        float goldAmount;
        string goldText;

        if (pressStart)
        { 
            PauseMenuStatusChange();
        }

        goldAmount = gameManager.GetComponent<LevelManager>().Money;
        goldText = "x " + goldAmount;
        HUDText.GetComponent<Text>().text = goldText;

	}

}
