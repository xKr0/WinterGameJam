using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager
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

    Dictionary<ColorList, Color> ColorEnumToColor = new Dictionary<ColorList, Color>();

    private static ColorManager instance;

    private ColorManager()
    {
        ColorEnumToColor.Add(ColorList.Red, new Color(255, 0, 0));
        ColorEnumToColor.Add(ColorList.Blue, new Color(0, 0, 255));
        ColorEnumToColor.Add(ColorList.Green, new Color(0, 255, 0));
        ColorEnumToColor.Add(ColorList.Black, new Color(0, 0, 0));
        ColorEnumToColor.Add(ColorList.White, new Color(255, 255, 255));
        ColorEnumToColor.Add(ColorList.Gray, new Color(142, 142, 142));
        ColorEnumToColor.Add(ColorList.Yellow, new Color(255, 255, 0));
        ColorEnumToColor.Add(ColorList.Cyan, new Color(0, 234, 255));
        ColorEnumToColor.Add(ColorList.Magenta, new Color(220, 0, 255));
        ColorEnumToColor.Add(ColorList.Trash, new Color(33, 33, 0));
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

    public int GetColorCount()
    {
        return ColorEnumToColor.Count;
    }
}
