using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;

    [SerializeField] Transform gameManager;

    [SerializeField] Sprite buttonSelected;
    [SerializeField] Sprite buttonNotSelected;

    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform HUD;
    [SerializeField] Transform gameOverMenu;
    [SerializeField] Transform backGO;
    [SerializeField] Transform controls;

    [SerializeField] Transform reprendre;
    [SerializeField] Transform controles;
    [SerializeField] Transform quitter;
    [SerializeField] Transform back;

    private AudioSource source;

    // Pause Menu
    public static bool isPaused = false;
    public static bool pressStart = false;

    // HUD
    [SerializeField]
    private Transform HUDText;

    private bool isGameOver;

    void Awake()
    {

        pauseMenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
        gameOverMenu.gameObject.SetActive(false);

        source = gameManager.gameObject.GetComponent<AudioSource>();
        //Debug.Log(source != null);
        //source.playOnAwake = false;

        //HUDText = HUD.GetChild(0).Find("Gold").Find("GoldLevel");
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

    public void ShowControls()
    {
        controls.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        // Select the button
        back.GetComponent<Button>().Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
        UnselectItem(controles);
    }
    public void HideControls()
    {
        controls.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        // Select the button
        reprendre.GetComponent<Button>().Select();
        UnselectItem(back);
    }
        

    public void SelectItem(Transform button)
    {
        button.GetComponent<Image>().sprite = buttonSelected;
        //source.clip = changeSound;
        //Debug.Log("ici " + source.clip != null);

    }
    public void UnselectItem(Transform button)
    {
        button.GetComponent<Image>().sprite = buttonNotSelected;
        //source.Play();
    }

    void Update()
	{
        float goldAmount;
        string goldText;
        if (LevelManager.NB_FAILS >= 5)
        {
            Time.timeScale = 0f;
            gameOverMenu.gameObject.SetActive(true);
            backGO.GetComponent<Button>().Select();
        }
        if (pressStart)
        { 
            PauseMenuStatusChange();
        }

        goldAmount = gameManager.GetComponent<LevelManager>().Money;
        goldText = "x " + goldAmount;
        HUDText.GetComponent<Text>().text = goldText;

	}

    public void BackToMenu(){
        PlayerSpec.canMove = true;
        Time.timeScale = m_TimeScaleRef;
        SceneManager.LoadScene("Launch");
    }

}
