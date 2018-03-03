using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModule : MonoBehaviour {

    Combinaison combinaison;

    Material material;

    [SerializeField]
    ParticleSystem particleExplosion;

    [SerializeField]
    ColorManager.ColorList myColor;

    public ColorManager.ColorList MyColor {
        get { return myColor; }
        set { myColor = value; }
    }

	// Use this for initialization
	void Start () {        
        material = GetComponentInChildren<Renderer>().material;

        material.SetColor("_Color", ColorManager.Instance.GetColorByEnum(myColor));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if it's another sheep
        if (collision.gameObject.tag.Equals(this.gameObject.tag))
        {
            particleExplosion.Play();
            material.SetColor("_Color", Combinaison.Instance.Combine(myColor, collision.gameObject.GetComponent<ColorModule>().MyColor));

        }        
    }
}
