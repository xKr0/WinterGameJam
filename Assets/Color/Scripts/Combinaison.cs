using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorManager.ColorList[,] combinaisons;

    ColorManager colorManager;

    public Combinaison(ColorManager colorManager)
    {
        this.colorManager = colorManager;

        combinaisons = new ColorManager.ColorList[colorManager.GetColorCount(), colorManager.GetColorCount()];

        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            for (int j = 0; j < colorManager.GetColorCount(); j++)
            {
                combinaisons[i,j] = ColorManager.ColorList.Trash;
            }
        }   
        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            combinaisons[i, i] = (ColorManager.ColorList)i;
        }
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Green, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Blue, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Blue, ColorManager.ColorList.Green, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.White, ColorManager.ColorList.Black, ColorManager.ColorList.Gray);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.White, ColorManager.ColorList.Pink);
    }

    private void AddCombinaison(ColorManager.ColorList colorA, ColorManager.ColorList colorB, ColorManager.ColorList colorC)
    {
        combinaisons[(int)colorA,(int)colorB] = colorC;
        combinaisons[(int)colorB,(int)colorA] = colorC;
    }

    public ColorManager.ColorList Combine(ColorManager.ColorList colorA, ColorManager.ColorList colorB)
    {
        return (ColorManager.ColorList)(combinaisons[(int)colorA,(int)colorB]);
    }
}
