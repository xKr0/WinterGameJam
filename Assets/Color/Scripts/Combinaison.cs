using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorManager.ColorList[,] combinaisons;

    public Combinaison(ColorManager colorManager)
    {
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

        // line 1 (Red)
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Yellow, ColorManager.ColorList.Orange);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Green, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Cyan, ColorManager.ColorList.White);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Blue, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Red, ColorManager.ColorList.Magenta, ColorManager.ColorList.Pink);

        // line 2 (Orange)
        AddCombinaison(ColorManager.ColorList.Orange, ColorManager.ColorList.Apple, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Orange, ColorManager.ColorList.Sky, ColorManager.ColorList.White);
        AddCombinaison(ColorManager.ColorList.Orange, ColorManager.ColorList.Pink, ColorManager.ColorList.Red);
        AddCombinaison(ColorManager.ColorList.Orange, ColorManager.ColorList.White, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Orange, ColorManager.ColorList.Black, ColorManager.ColorList.Red);

        // line 3 (Yellow)
        AddCombinaison(ColorManager.ColorList.Yellow, ColorManager.ColorList.Green, ColorManager.ColorList.Apple);
        AddCombinaison(ColorManager.ColorList.Yellow, ColorManager.ColorList.Cyan, ColorManager.ColorList.Green);
        AddCombinaison(ColorManager.ColorList.Yellow, ColorManager.ColorList.Blue, ColorManager.ColorList.White);
        AddCombinaison(ColorManager.ColorList.Yellow, ColorManager.ColorList.Magenta, ColorManager.ColorList.Red);

        // line 4 (Apple)
        AddCombinaison(ColorManager.ColorList.Apple, ColorManager.ColorList.Turqoise, ColorManager.ColorList.Green);
        AddCombinaison(ColorManager.ColorList.Apple, ColorManager.ColorList.Purple, ColorManager.ColorList.White);
        AddCombinaison(ColorManager.ColorList.Apple, ColorManager.ColorList.White, ColorManager.ColorList.Yellow);
        AddCombinaison(ColorManager.ColorList.Apple, ColorManager.ColorList.Black, ColorManager.ColorList.Green);

        // line 5 (Green)
        AddCombinaison(ColorManager.ColorList.Green, ColorManager.ColorList.Cyan, ColorManager.ColorList.Turqoise);
        AddCombinaison(ColorManager.ColorList.Green, ColorManager.ColorList.Blue, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.Green, ColorManager.ColorList.Magenta, ColorManager.ColorList.White);

        // line 6 (Turqoise)
        AddCombinaison(ColorManager.ColorList.Turqoise, ColorManager.ColorList.Sky, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.Turqoise, ColorManager.ColorList.Pink, ColorManager.ColorList.White);
        AddCombinaison(ColorManager.ColorList.Turqoise, ColorManager.ColorList.White, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.Turqoise, ColorManager.ColorList.Black, ColorManager.ColorList.Green);

        // line 7 (Cyan)
        AddCombinaison(ColorManager.ColorList.Cyan, ColorManager.ColorList.Blue, ColorManager.ColorList.Sky);
        AddCombinaison(ColorManager.ColorList.Cyan, ColorManager.ColorList.Magenta, ColorManager.ColorList.Blue);

        // line 8 (Sky)
        AddCombinaison(ColorManager.ColorList.Sky, ColorManager.ColorList.Purple, ColorManager.ColorList.Blue);
        AddCombinaison(ColorManager.ColorList.Sky, ColorManager.ColorList.White, ColorManager.ColorList.Cyan);
        AddCombinaison(ColorManager.ColorList.Sky, ColorManager.ColorList.Black, ColorManager.ColorList.Blue);

        // line 9 (Blue)
        AddCombinaison(ColorManager.ColorList.Blue, ColorManager.ColorList.Magenta, ColorManager.ColorList.Purple);

        // line 10 (Purple)
        AddCombinaison(ColorManager.ColorList.Purple, ColorManager.ColorList.Pink, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Purple, ColorManager.ColorList.White, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Purple, ColorManager.ColorList.Black, ColorManager.ColorList.Blue);

        // line 11 (Magenta)

        // line 12 (Pink)
        AddCombinaison(ColorManager.ColorList.Pink, ColorManager.ColorList.White, ColorManager.ColorList.Magenta);
        AddCombinaison(ColorManager.ColorList.Pink, ColorManager.ColorList.Black, ColorManager.ColorList.Red);

        // line 13 (White)
        AddCombinaison(ColorManager.ColorList.White, ColorManager.ColorList.Black, ColorManager.ColorList.Grey);
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
