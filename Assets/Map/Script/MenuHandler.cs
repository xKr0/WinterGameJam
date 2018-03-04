using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuHandler : MonoBehaviour {

    [Tooltip("Scene to load")]
    [SerializeField]
    string scene;

    [Tooltip("Panels for the menu")]
    [SerializeField] GameObject basicMenu;
    [SerializeField] GameObject controles;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject backControls;
    [SerializeField] GameObject backCredits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Play(){
        SceneManager.LoadScene(scene);
    }

    public void Credits(){
        basicMenu.SetActive(false);
        credits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backCredits);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Controls(){
        basicMenu.SetActive(false);
        controles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backControls);
    }

    public void Back(){
        basicMenu.SetActive(true);
        credits.SetActive(false);
        controles.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}
