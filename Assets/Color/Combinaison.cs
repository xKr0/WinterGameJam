using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorManager.ColorList[][] combinaisons;

    private static Combinaison instance;


    /**
     * public enum ColorList
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
     * */
    private Combinaison()
    {
        for (int i = 0; i < ColorManager.Instance.GetColorCount(); i++)
        {
            for (int j = 0; j < ColorManager.Instance.GetColorCount(); j++)
            {
                combinaisons[i][j] = ColorManager.ColorList.Trash;
            }
        }   
        for (int i = 0; i < ColorManager.Instance.GetColorCount(); i++)
        {
            combinaisons[i][i] = (ColorManager.ColorList)i;
        }
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Green, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Blue, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Blue, ColorManager.ColorList.Green, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.White, ColorManager.ColorList.Black, ColorManager.ColorList.Gray);
    }

    public static Combinaison Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Combinaison();
            }
            return instance;
        }
    }

    private void AddCombinaison(ColorManager.ColorList colorA, ColorManager.ColorList colorB, ColorManager.ColorList colorC){
        combinaisons[(int)colorA][(int)colorB] = colorC;
        combinaisons[(int)colorB][(int)colorA] = colorC;
    }

    public ColorManager.ColorList Combine(ColorManager.ColorList colorA, ColorManager.ColorList colorB){
        return (ColorManager.ColorList)(combinaisons[(int)colorA][(int)colorB]);
       
    }

}
