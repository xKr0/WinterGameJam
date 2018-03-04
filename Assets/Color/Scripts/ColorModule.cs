﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModule : MonoBehaviour {
    [SerializeField]
    Renderer sheepRenderer;

    Material material;

    [SerializeField]
    ParticleSystem particleExplosion;

    [SerializeField]
    ParticleSystem trail;

    [SerializeField]
    ColorList myColor;

    ColorManager colorManager;

    public ColorList MyColor {
        get { return myColor; }
        set { myColor = value; }
    }

	// Use this for initialization
	void Start () {
        colorManager = FindObjectOfType<ColorManager>();

        material = sheepRenderer.material;

        SetSheepColor(myColor);
    }

    public void SetSheepColor(ColorList color)
    {
        this.myColor = color;
        material.SetTexture("_MainTex", colorManager.GetTextureByColorEnum(color));
        ParticleSystem.MainModule settings = trail.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(colorManager.ConvertColor(colorManager.GetColorFromEnum(myColor)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if it's another sheep
        if (collision.gameObject.tag.Equals(this.gameObject.tag) && collision.gameObject.GetComponent<ColorModule>().MyColor != myColor)
        {
            particleExplosion.Play();
            ColorList color = colorManager.Combine(myColor, collision.gameObject.GetComponent<ColorModule>().MyColor);
            SetSheepColor(color);
            collision.gameObject.GetComponent<ColorModule>().SetSheepColor(color);
        }        
    }
}
