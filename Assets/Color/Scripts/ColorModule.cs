using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModule : MonoBehaviour {

    Material material;

    [SerializeField]
    ParticleSystem particleExplosion;

    [SerializeField]
    ColorManager.ColorList myColor;

    ColorManager colorManager;

    public ColorManager.ColorList MyColor {
        get { return myColor; }
        set { myColor = value; }
    }

	// Use this for initialization
	void Start () {
        colorManager = FindObjectOfType<ColorManager>();

        material = GetComponentInChildren<Renderer>().material;

        SetSheepColor(myColor);
    }

    public void SetSheepColor(ColorManager.ColorList color)
    {
        this.myColor = color;
        material.SetTexture("_MainTex", colorManager.GetColorByEnum(color));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if it's another sheep
        if (collision.gameObject.tag.Equals(this.gameObject.tag) && collision.gameObject.GetComponent<ColorModule>().MyColor != myColor)
        {
            particleExplosion.Play();
            ColorManager.ColorList color = colorManager.Combine(myColor, collision.gameObject.GetComponent<ColorModule>().MyColor);
            SetSheepColor(color);
            collision.gameObject.GetComponent<ColorModule>().SetSheepColor(color);
        }        
    }
}
