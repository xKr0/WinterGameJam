using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager
{
    enum ColorList
    {
        Red,
        Blue,
        Green,
        Black,
        White,
        Gray,
        Yellow,
        Cyan,
        Magenta
    }

    Dictionary<ColorList, Color> ColorEnumToColor = new Dictionary<ColorList, Color>();

    private static ColorManager instance;

    private ColorManager()
    {
        ColorEnumToColor.Add(ColorList.Red, new Color(255, 0, 0));
    }

    public static ColorManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ColorManager();
            }
            return instance;
        }
    }

}
