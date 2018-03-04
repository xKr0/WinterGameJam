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

    Dictionary<ColorList, Color> EnumToColor;

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

    public Color GetColorFromEnum(ColorList theEnum)
    {
        return EnumToColor[theEnum];
    }

    private void Start()
    {
        combinaison = new Combinaison(this);
        EnumToColor = new Dictionary<ColorList, Color>();
        EnumToColor.Add(ColorList.Red, new Color(218,8,2));
        EnumToColor.Add(ColorList.Orange, new Color(246,144,5));
        EnumToColor.Add(ColorList.Yellow, new Color(231,255,29));
        EnumToColor.Add(ColorList.Apple, new Color(91,235,104));
        EnumToColor.Add(ColorList.Green, new Color(8,203,44));
        EnumToColor.Add(ColorList.Turqoise, new Color(92,235,174));
        EnumToColor.Add(ColorList.Cyan, new Color(172,248,223));
        EnumToColor.Add(ColorList.Sky, new Color(60,148,245));
        EnumToColor.Add(ColorList.Blue, new Color(38,65,228));
        EnumToColor.Add(ColorList.Purple, new Color(101,37,182));
        EnumToColor.Add(ColorList.Magenta, new Color(213,103,159));
        EnumToColor.Add(ColorList.Pink, new Color(247,46,125));
        EnumToColor.Add(ColorList.White, new Color(247,247,247));
        EnumToColor.Add(ColorList.Black, new Color(21,21,21));
        EnumToColor.Add(ColorList.Grey, new Color(99,99,103));
        EnumToColor.Add(ColorList.Trash, new Color(69,48,0));
    }
}
