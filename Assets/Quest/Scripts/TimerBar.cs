using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour {

    private float initialValue;
    [SerializeField] private Image fill;
    public Color col;

    // Use this for initialization
    void Start()
    {
        initialValue = this.gameObject.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Slider>().value = this.gameObject.GetComponent<Slider>().value - (1.0f * Time.deltaTime);
        if (this.gameObject.GetComponent<Slider>().value <= initialValue / 10)
        {
            fill.color = Color.red;
        }

        else if (this.gameObject.GetComponent<Slider>().value <= initialValue / 2 && this.gameObject.GetComponent<Slider>().value >= initialValue / 10)
        {
            fill.color = Color.yellow;
        }
    }
}