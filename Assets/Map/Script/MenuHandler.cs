using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] Sprite buttonSelected;
    [SerializeField] Sprite buttonNotSelected;
    [SerializeField] Transform controlsButton;
    [SerializeField] Transform creditsButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Play(){
        Application.LoadLevel(scene);
    }

    public void Credits(){
        basicMenu.SetActive(false);
        credits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backCredits);
        UnselectItem(creditsButton);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Controls(){
        basicMenu.SetActive(false);
        controles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backControls);
        UnselectItem(controlsButton);
    }

    public void Back(){
        basicMenu.SetActive(true);
        credits.SetActive(false);
        controles.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton);
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
}
