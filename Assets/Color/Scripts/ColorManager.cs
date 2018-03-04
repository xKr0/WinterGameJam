using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorSheepEnum
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

public class ColorManager : MonoBehaviour
{    
    [Tooltip("Attention les textures doivent être dans l'ordre exacte de ColorList")]
    [SerializeField]
    Texture[] colorTexture = new Texture[16];

    Dictionary<ColorSheepEnum, Color> enumToColor = new Dictionary<ColorSheepEnum, Color>(){
        {ColorSheepEnum.Red, new Color(218,8,2)},
        {ColorSheepEnum.Orange, new Color(246,144,5)},
        {ColorSheepEnum.Yellow, new Color(231,255,29)},
        {ColorSheepEnum.Apple, new Color(91,235,104)},
        {ColorSheepEnum.Green, new Color(8,203,44)},
        {ColorSheepEnum.Turqoise, new Color(92,235,174)},
        {ColorSheepEnum.Cyan, new Color(172,248,223)},
        {ColorSheepEnum.Sky, new Color(60,148,245)},
        {ColorSheepEnum.Blue, new Color(38,65,228)},
        {ColorSheepEnum.Purple, new Color(101,37,182)},
        {ColorSheepEnum.Magenta, new Color(213,103,159)},
        {ColorSheepEnum.Pink, new Color(247,46,125)},
        {ColorSheepEnum.White, new Color(247,247,247)},
        {ColorSheepEnum.Black, new Color(21,21,21)},
        {ColorSheepEnum.Grey, new Color(99,99,103)},
        {ColorSheepEnum.Trash, new Color(69,48,0)}
    };

    static string[] stringToEnum = new string[16] {
        "Red",
        "Orange",
        "Yellow",
        "Apple",
        "Green",
        "Turqoise",
        "Cyan",
        "Sky",
        "Blue",
        "Purple",
        "Magenta",
        "Pink",
        "White",
        "Black",
        "Grey",
        "Trash"
    };
    public static ColorSheepEnum GetEnumByName(string colorName)
    {
        for (int i = 0; i < stringToEnum.Length; i++)
        {
            if (stringToEnum[i].Equals(colorName))
            {
                return (ColorSheepEnum)i;
            }
        }

        return (ColorSheepEnum) (-1);
    }

    Combinaison combinaison;

    public Color ConvertColor(Color color){
        return new Color(color.r / 255f, color.g / 255f, color.b / 255f);
    }

    public int GetColorCount()
    {
        return colorTexture.Length;
    }

    public Texture GetTextureByColorEnum(ColorSheepEnum colorList)
    {
        return colorTexture[(int)colorList];
    }

    public ColorSheepEnum Combine(ColorSheepEnum colorA, ColorSheepEnum colorB)
    {
        return combinaison.Combine(colorA, colorB);
    }

    public Color GetColorFromEnum(ColorSheepEnum theEnum)
    {
        return enumToColor[theEnum];
    }

    private void Start()
    {
        combinaison = new Combinaison(this);
    }
}
