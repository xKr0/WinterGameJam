using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum ColorList
    {
        Red,
        Blue,
        Green,
        Black,
        White,
        Gray,
        Yellow,
        Cyan,
        Magenta,
        Trash
    }

    [Tooltip("Attention les textures doivent être dans l'ordre exacte de ColorList")]
    [SerializeField]
    Texture[] colorTexture = new Texture[10];

    Combinaison combinaison;

    public int GetColorCount()
    {
        return colorTexture.Length;
    }

    public Texture GetColorByEnum(ColorList colorList)
    {
        return colorTexture[(int)colorList];
    }

    public ColorList Combine(ColorList colorA, ColorList colorB)
    {
        Debug.Log(combinaison);
        return combinaison.Combine(colorA, colorB);
    }

    private void Start()
    {
        combinaison = new Combinaison(this);
    }
}
