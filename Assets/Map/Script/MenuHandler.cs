using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuHandler : MonoBehaviour {

    [Tooltip("Scene to load")]
    [SerializeField]
    string scene;

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
        SceneManager.LoadScene(scene);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Controls(){
        SceneManager.LoadScene(scene);
    }
}
