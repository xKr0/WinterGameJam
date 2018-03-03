using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;

    public static bool isPaused = false;
    public static bool isGameOver;
    GameObject pauseMenu;


    void Awake()
    {

	}


    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        isPaused = true;
    }


    public void MenuOff ()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        isPaused = false;
    }

    // Sera appelée dans le Input manager en appuyant sur start
    public void OnMenuStatusChange ()
    {
        isPaused = !isPaused;
        Cursor.visible = isPaused; //force the cursor visible if anythign had hidden it
        if (!isPaused)
        {
            MenuOn();
        }
        else if (isPaused)
        {
            MenuOff();
        }
    }


#if !MOBILE_INPUT
	void Update()
	{
		
	}
#endif

}
