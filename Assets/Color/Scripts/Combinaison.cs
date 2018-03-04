using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison  {

    public ColorList[,] combinaisons;

    public Combinaison(ColorManager colorManager)
    {
        combinaisons = new  ColorList[colorManager.GetColorCount(), colorManager.GetColorCount()];

        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            for (int j = 0; j < colorManager.GetColorCount(); j++)
            {
                combinaisons[i,j] = ColorList.Trash;
            }
        }   
        for (int i = 0; i < colorManager.GetColorCount(); i++)
        {
            combinaisons[i, i] = (ColorList)i;
        }

        // line 1 (Red)
        AddCombinaison(ColorList.Red, ColorList.Yellow, ColorList.Orange);
        AddCombinaison(ColorList.Red, ColorList.Green, ColorList.Yellow);
        AddCombinaison(ColorList.Red, ColorList.Cyan, ColorList.White);
        AddCombinaison(ColorList.Red, ColorList.Blue, ColorList.Magenta);
        AddCombinaison(ColorList.Red, ColorList.Magenta, ColorList.Pink);

        // line 2 (Orange)
        AddCombinaison(ColorList.Orange, ColorList.Apple, ColorList.Yellow);
        AddCombinaison(ColorList.Orange, ColorList.Sky, ColorList.White);
        AddCombinaison(ColorList.Orange, ColorList.Pink, ColorList.Red);
        AddCombinaison(ColorList.Orange, ColorList.White, ColorList.Yellow);
        AddCombinaison(ColorList.Orange, ColorList.Black, ColorList.Red);

        // line 3 (Yellow)
        AddCombinaison(ColorList.Yellow, ColorList.Green, ColorList.Apple);
        AddCombinaison(ColorList.Yellow, ColorList.Cyan, ColorList.Green);
        AddCombinaison(ColorList.Yellow, ColorList.Blue, ColorList.White);
        AddCombinaison(ColorList.Yellow, ColorList.Magenta, ColorList.Red);

        // line 4 (Apple)
        AddCombinaison(ColorList.Apple, ColorList.Turqoise, ColorList.Green);
        AddCombinaison(ColorList.Apple, ColorList.Purple, ColorList.White);
        AddCombinaison(ColorList.Apple, ColorList.White, ColorList.Yellow);
        AddCombinaison(ColorList.Apple, ColorList.Black, ColorList.Green);

        // line 5 (Green)
        AddCombinaison(ColorList.Green, ColorList.Cyan, ColorList.Turqoise);
        AddCombinaison(ColorList.Green, ColorList.Blue, ColorList.Cyan);
        AddCombinaison(ColorList.Green, ColorList.Magenta, ColorList.White);

        // line 6 (Turqoise)
        AddCombinaison(ColorList.Turqoise, ColorList.Sky, ColorList.Cyan);
        AddCombinaison(ColorList.Turqoise, ColorList.Pink, ColorList.White);
        AddCombinaison(ColorList.Turqoise, ColorList.White, ColorList.Cyan);
        AddCombinaison(ColorList.Turqoise, ColorList.Black, ColorList.Green);

        // line 7 (Cyan)
        AddCombinaison(ColorList.Cyan, ColorList.Blue, ColorList.Sky);
        AddCombinaison(ColorList.Cyan, ColorList.Magenta, ColorList.Blue);

        // line 8 (Sky)
        AddCombinaison(ColorList.Sky, ColorList.Purple, ColorList.Blue);
        AddCombinaison(ColorList.Sky, ColorList.White, ColorList.Cyan);
        AddCombinaison(ColorList.Sky, ColorList.Black, ColorList.Blue);

        // line 9 (Blue)
        AddCombinaison(ColorList.Blue, ColorList.Magenta, ColorList.Purple);

        // line 10 (Purple)
        AddCombinaison(ColorList.Purple, ColorList.Pink, ColorList.Magenta);
        AddCombinaison(ColorList.Purple, ColorList.White, ColorList.Magenta);
        AddCombinaison(ColorList.Purple, ColorList.Black, ColorList.Blue);

        // line 11 (Magenta)

        // line 12 (Pink)
        AddCombinaison(ColorList.Pink, ColorList.White, ColorList.Magenta);
        AddCombinaison(ColorList.Pink, ColorList.Black, ColorList.Red);

        // line 13 (White)
        AddCombinaison(ColorList.White, ColorList.Black, ColorList.Grey);
    }

    private void AddCombinaison(ColorList colorA, ColorList colorB, ColorList colorC)
    {
        combinaisons[(int)colorA,(int)colorB] = colorC;
        combinaisons[(int)colorB,(int)colorA] = colorC;
    }

    public ColorList Combine(ColorList colorA, ColorList colorB)
    {
        return (ColorList)(combinaisons[(int)colorA,(int)colorB]);
    }
}
