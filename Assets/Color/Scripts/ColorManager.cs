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

    Dictionary<ColorList, Color> enumToColor = new Dictionary<ColorList, Color>(){
        {ColorList.Red, new Color(218,8,2)},
        {ColorList.Orange, new Color(246,144,5)},
        {ColorList.Yellow, new Color(231,255,29)},
        {ColorList.Apple, new Color(91,235,104)},
        {ColorList.Green, new Color(8,203,44)},
        {ColorList.Turqoise, new Color(92,235,174)},
        {ColorList.Cyan, new Color(172,248,223)},
        {ColorList.Sky, new Color(60,148,245)},
        {ColorList.Blue, new Color(38,65,228)},
        {ColorList.Purple, new Color(101,37,182)},
        {ColorList.Magenta, new Color(213,103,159)},
        {ColorList.Pink, new Color(247,46,125)},
        {ColorList.White, new Color(247,247,247)},
        {ColorList.Black, new Color(21,21,21)},
        {ColorList.Grey, new Color(99,99,103)},
        {ColorList.Trash, new Color(69,48,0)}
    };

    Combinaison combinaison;

    public Color ConvertColor(Color color){
        return new Color(color.r / 255f, color.g / 255f, color.b / 255f);
    }

    public int GetColorCount()
    {
        return colorTexture.Length;
    }

    public Texture GetTextureByColorEnum(ColorList colorList)
    {
        return colorTexture[(int)colorList];
    }

    public ColorList Combine(ColorList colorA, ColorList colorB)
    {
        return combinaison.Combine(colorA, colorB);
    }

    public Color GetColorFromEnum(ColorList theEnum)
    {
        return enumToColor[theEnum];
    }

    private void Start()
    {
        combinaison = new Combinaison(this);
    }
}
