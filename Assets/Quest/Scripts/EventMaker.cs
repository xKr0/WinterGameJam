using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventMaker :MonoBehaviour {

    GameObject[] allSheeps;

    public GameObject[] AllSheeps {get{ return allSheeps; } set{ allSheeps = value; }}

    int NB_NEVENT = 3;
    int NB_PEVENT = 1;

    [SerializeField] Animator anim;
    [SerializeField] Text text;
    [SerializeField] float propulsion = 500f;
    [SerializeField] Camera cameraEvent;
    [SerializeField] Camera cameraPlayer;
    [SerializeField] float duration;
    bool playingEvent;
    float timer = 0;


    void Update(){
        if (playingEvent)
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                StopEffect();
            }
        }
    }

    void LaunchEffect(){
        anim.SetTrigger("playEvent");
        playingEvent = true;
        PlayerSpec.canMove = false;
        cameraEvent.gameObject.SetActive(true);
        cameraPlayer.gameObject.SetActive(false);


    }

    void StopEffect(){
        timer = 0;
        playingEvent = false;
        cameraPlayer.gameObject.SetActive(true);
        cameraEvent.gameObject.SetActive(false);
        PlayerSpec.canMove = true;
    }

    public void RandomNegativeEvent(){
        allSheeps = GameObject.FindGameObjectsWithTag("Sheep");
        int choice = Random.Range(1, NB_NEVENT);
        switch (choice)
        {
            case 1:
                text.text = "RANDOM COLOR!";
                Invoke("RandomizeColony",2.5f);
                break;
            case 2:
                text.text = "EVERYBODY DANCE!";
                Invoke("EverybodyDance",2.5f);
                break;
            case 3:
                text.text = "DISEASE!";
                Invoke("RandomClean",2.5f);
                break;
            default:
                break;
        }
        LaunchEffect();
    }

    public void RandomPositiveEvent(){
        allSheeps = GameObject.FindGameObjectsWithTag("Sheep");
        int choice = Random.Range(1, NB_PEVENT);

        switch (choice)
        {
            case 1:
                text.text = "PURGE!";
                Invoke("Purge",2.5f);
                break;
            default:
                break;
        }
        LaunchEffect();
    }

    public void RandomizeColony(){
       
        for (int i = 0; i < allSheeps.Length; i++)
        {
            int randomColorEnum = Random.Range(0, 15);
            allSheeps[i].GetComponent<ColorModule>().ParticleExplosion.Play();
            allSheeps[i].GetComponent<ColorModule>().SetSheepColor((ColorSheepEnum)randomColorEnum);
        }
    }

    public void EverybodyDance(){
       
        for (int i = 0; i < allSheeps.Length; i++)
        {
            allSheeps[i].GetComponent<Rigidbody>().AddForce(allSheeps[i].GetComponent<Transform>().forward * propulsion);
        }
    }

    public void RandomClean(){

        for (int i = 0; i < allSheeps.Length/0.2f; i++)
        {
            allSheeps[i].GetComponent<ColorModule>().ParticleExplosion.Play();
            GameObject.Destroy(allSheeps[i], 0.5f);
        }
    }

    public void Purge(){

        for (int i = 0; i < allSheeps.Length; i++)
        {
            if (allSheeps[i].GetComponent<ColorModule>().MyColor == ColorSheepEnum.Trash)
            {
                allSheeps[i].GetComponent<ColorModule>().ParticleExplosion.Play();
                GameObject.Destroy(allSheeps[i], 0.5f);
            }   
        }
    }


    //purge kill trashes
}
