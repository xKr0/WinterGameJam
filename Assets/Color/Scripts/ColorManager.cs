using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum ColorList
    {
        Red,
        Orange,
        Yellow,
        Apple,
        Green,
        Turqoise,
        Cyan,
        Sky,
        Blue,
        Purple,
        Magenta,
        Pink,
        White,
        Black,
        Grey,
        Trash
    }

    [Tooltip("Attention les textures doivent être dans l'ordre exacte de ColorList")]
    [SerializeField]
    Texture[] colorTexture = new Texture[16];

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
        return combinaison.Combine(colorA, colorB);
    }

    private void Start()
    {
        combinaison = new Combinaison(this);
    }
}
